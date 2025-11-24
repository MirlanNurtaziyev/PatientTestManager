using PatientTestManager.Services.DTO;
using PatientTestManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PatientTestManager.UI
{
    public partial class MainForm : Form
    {
        private readonly IPatientService _patientService;
        private readonly ITestService _testService;
        private readonly IReportService _reportService;

        private BindingSource patientBindingSource = new();
        private BindingSource testBindingSource = new();

        private int selectedPatientId = 0;
        private int editingTestId = 0;
        private bool isUpdatingComboBox = false;
        private int lastSelectedTestPatientId = 0;

        public MainForm(IPatientService patientService, ITestService testService, IReportService reportService)
        {
            _patientService = patientService;
            _testService = testService;
            _reportService = reportService;

            InitializeComponent();
            ConfigureDataGridViews();
            HideUnwantedColumns();
            InitializeFormAsync();
        }

        private async void InitializeFormAsync()
        {
            await LoadPatientsAsync();
        }

        private void ConfigureDataGridViews()
        {
            dgvPatients.DataSource = patientBindingSource;
            dgvTests.DataSource = testBindingSource;

            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
            dgvTests.SelectionChanged += DgvTests_SelectionChanged;
            cmbTestPatient.SelectedIndexChanged += CmbTestPatient_SelectedIndexChanged;
        }

        private void HideUnwantedColumns()
        {
            try
            {
                if (dgvPatients.Columns.Contains("Id"))
                {
                    dgvPatients.Columns["Id"].Visible = false;
                }
                if (dgvPatients.Columns.Contains("Tests"))
                {
                    dgvPatients.Columns["Tests"].Visible = false;
                }

                if (dgvTests.Columns.Contains("Id"))
                {
                    dgvTests.Columns["Id"].Visible = false;
                }
                if (dgvTests.Columns.Contains("Patient"))
                {
                    dgvTests.Columns["Patient"].Visible = false;
                }
                if (dgvTests.Columns.Contains("PatientId"))
                {
                    dgvTests.Columns["PatientId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error hiding columns: {ex.Message}");
            }
        }

        #region Patient Operations

        private async Task LoadPatientsAsync()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();
                patientBindingSource.DataSource = patients.ToList();
                UpdateTestPatientCombo();
                HideUnwantedColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (patientBindingSource.Current is PatientDto patient)
            {
                selectedPatientId = patient.Id;
                PopulatePatientInputs(patient);
                await LoadTestsForPatientAsync(patient.Id);
            }
        }

        private void PopulatePatientInputs(PatientDto patient)
        {
            txtPatientName.Text = patient.Name;
            dtpPatientDOB.Value = patient.DateOfBirth;
            cmbPatientGender.SelectedItem = patient.Gender;
        }

        private async void BtnAddPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatePatientInputs())
                    return;

                var patientDto = new PatientDto
                {
                    Name = txtPatientName.Text.Trim(),
                    DateOfBirth = dtpPatientDOB.Value,
                    Gender = cmbPatientGender.SelectedItem.ToString()
                };

                await _patientService.CreatePatientAsync(patientDto);
                MessageBox.Show("Patient added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearPatientInputs();
                await RefreshPatientsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdatePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatientId <= 0)
                {
                    MessageBox.Show("Please select a patient to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidatePatientInputs())
                    return;

                var patientDto = new PatientDto
                {
                    Id = selectedPatientId,
                    Name = txtPatientName.Text.Trim(),
                    DateOfBirth = dtpPatientDOB.Value,
                    Gender = cmbPatientGender.SelectedItem.ToString()
                };

                await _patientService.UpdatePatientAsync(patientDto);
                MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearPatientInputs();
                await RefreshPatientsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDeletePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatientId <= 0)
                {
                    MessageBox.Show("Please select a patient to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    "Are you sure you want to delete this patient? All associated tests will be deleted.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                await _patientService.DeletePatientAsync(selectedPatientId);
                MessageBox.Show("Patient deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearPatientInputs();
                await RefreshPatientsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearPatient_Click(object sender, EventArgs e)
        {
            ClearPatientInputs();
            patientBindingSource.Position = -1;
        }

        private void ClearPatientInputs()
        {
            txtPatientName.Clear();
            dtpPatientDOB.Value = DateTime.Now;
            cmbPatientGender.SelectedIndex = 0;
            selectedPatientId = 0;
        }

        private bool ValidatePatientInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Patient name is required. Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientName.Focus();
                return false;
            }

            if (txtPatientName.Text.Trim().Length > 200)
            {
                MessageBox.Show("Patient name must not exceed 200 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientName.Focus();
                return false;
            }

            if (cmbPatientGender.SelectedIndex < 0)
            {
                MessageBox.Show("Gender is required. Please select a gender from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPatientGender.Focus();
                return false;
            }

            if (dtpPatientDOB.Value > DateTime.Now)
            {
                MessageBox.Show("Date of birth cannot be in the future. Please select a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpPatientDOB.Focus();
                return false;
            }

            var age = DateTime.Now.Year - dtpPatientDOB.Value.Year;
            if (dtpPatientDOB.Value.Date > DateTime.Now.AddYears(-age))
                age--;

            if (age > 150)
            {
                MessageBox.Show("Date of birth appears to be too far in the past. Please enter a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpPatientDOB.Focus();
                return false;
            }

            return true;
        }

        private async Task RefreshPatientsGridAsync()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();
                patientBindingSource.DataSource = patients.ToList();
                UpdateTestPatientCombo();
                ClearTestGrid();
                HideUnwantedColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTestGrid()
        {
            testBindingSource.DataSource = new List<TestDto>();
            ClearTestInputs();
        }

        #endregion

        #region Test Operations

        private async Task LoadTestsForPatientAsync(int patientId)
        {
            try
            {
                var tests = await _testService.GetTestsByPatientIdAsync(patientId);
                testBindingSource.DataSource = tests.ToList();
                HideUnwantedColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTestPatientCombo()
        {
            isUpdatingComboBox = true;
            try
            {
                var patients = patientBindingSource.DataSource as List<PatientDto>;
                var dataSource = new List<PatientDto>(patients ?? new List<PatientDto>());
                cmbTestPatient.DataSource = dataSource;
                cmbTestPatient.DisplayMember = "Name";
                cmbTestPatient.ValueMember = "Id";
                cmbTestPatient.SelectedIndex = -1;
            }
            finally
            {
                isUpdatingComboBox = false;
            }
        }

        private async void CmbTestPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingComboBox)
                return;

            if (cmbTestPatient.SelectedItem is PatientDto selectedPatient && selectedPatient.Id > 0)
            {
                lastSelectedTestPatientId = selectedPatient.Id;
                await LoadTestsForPatientAsync(selectedPatient.Id);
            }
        }

        private void DgvTests_SelectionChanged(object sender, EventArgs e)
        {
            if (testBindingSource.Current is TestDto test)
            {
                editingTestId = test.Id;
                lastSelectedTestPatientId = test.PatientId;
                PopulateTestInputs(test);
            }
        }

        private void PopulateTestInputs(TestDto test)
        {
            isUpdatingComboBox = true;
            try
            {
                cmbTestPatient.SelectedValue = test.PatientId;
                txtTestName.Text = test.TestName;
                dtpTestDate.Value = test.TestDate;
                txtTestResult.Text = test.Result.ToString();
                chkTestThreshold.Checked = test.IsWithinThreshold;
            }
            finally
            {
                isUpdatingComboBox = false;
            }
        }

        private async void BtnAddTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTestInputs())
                    return;

                var testDto = new TestDto
                {
                    PatientId = (int)cmbTestPatient.SelectedValue,
                    TestName = txtTestName.Text.Trim(),
                    TestDate = dtpTestDate.Value,
                    Result = decimal.Parse(txtTestResult.Text),
                    IsWithinThreshold = chkTestThreshold.Checked
                };

                var existingTest = await CheckForDuplicateTestAsync(testDto.PatientId, testDto.TestName);
                if (existingTest != null)
                {
                    var result = MessageBox.Show(
                        $"A test with the name '{testDto.TestName}' already exists for this patient.\n\nDo you want to update the existing test instead?",
                        "Duplicate Test Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        testDto.Id = existingTest.Id;
                        await _testService.UpdateTestAsync(testDto);
                        MessageBox.Show("Test updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    await _testService.CreateTestAsync(testDto);
                    MessageBox.Show("Test added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                int patientIdForRefresh = testDto.PatientId;
                ClearTestInputs();
                await RefreshTestsGridAsync(patientIdForRefresh);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding test: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdateTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (editingTestId <= 0)
                {
                    MessageBox.Show("Please select a test to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateTestInputs())
                    return;

                var testDto = new TestDto
                {
                    Id = editingTestId,
                    PatientId = (int)cmbTestPatient.SelectedValue,
                    TestName = txtTestName.Text.Trim(),
                    TestDate = dtpTestDate.Value,
                    Result = decimal.Parse(txtTestResult.Text),
                    IsWithinThreshold = chkTestThreshold.Checked
                };

                var existingTest = await CheckForDuplicateTestAsync(testDto.PatientId, testDto.TestName, excludeId: editingTestId);
                if (existingTest != null)
                {
                    var result = MessageBox.Show(
                        $"A test with the name '{testDto.TestName}' already exists for this patient.\n\nAre you sure you want to update this test with the same name?",
                        "Duplicate Test Name",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }

                int patientIdForRefresh = testDto.PatientId;

                await _testService.UpdateTestAsync(testDto);
                MessageBox.Show("Test updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTestInputs();
                await RefreshTestsGridAsync(patientIdForRefresh);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating test: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDeleteTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (editingTestId <= 0)
                {
                    MessageBox.Show("Please select a test to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    "Are you sure you want to delete this test?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                int patientIdForRefresh = lastSelectedTestPatientId;

                await _testService.DeleteTestAsync(editingTestId);
                MessageBox.Show("Test deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTestInputs();
                await RefreshTestsGridAsync(patientIdForRefresh);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting test: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearTest_Click(object sender, EventArgs e)
        {
            ClearTestInputs();
            testBindingSource.Position = -1;
        }

        private void ClearTestInputs()
        {
            isUpdatingComboBox = true;
            try
            {
                cmbTestPatient.SelectedIndex = -1;
                txtTestName.Clear();
                dtpTestDate.Value = DateTime.Now;
                txtTestResult.Clear();
                chkTestThreshold.Checked = false;
                editingTestId = 0;
            }
            finally
            {
                isUpdatingComboBox = false;
            }
        }

        private bool ValidateTestInputs()
        {
            if (cmbTestPatient.SelectedIndex < 0 || cmbTestPatient.SelectedValue == null)
            {
                MessageBox.Show("Patient is required. Please select a patient from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTestPatient.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                MessageBox.Show("Test name is required. Please enter a test name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTestName.Focus();
                return false;
            }

            if (txtTestName.Text.Trim().Length > 200)
            {
                MessageBox.Show("Test name must not exceed 200 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTestName.Focus();
                return false;
            }

            if (dtpTestDate.Value == DateTime.MinValue || dtpTestDate.Value > DateTime.Now)
            {
                MessageBox.Show("Test date cannot be in the future. Please enter a valid test date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTestDate.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTestResult.Text))
            {
                MessageBox.Show("Test result is required. Please enter a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTestResult.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTestResult.Text, out var result))
            {
                MessageBox.Show($"Test result must be a valid number. You entered: '{txtTestResult.Text}'. Please enter a numeric value (e.g., 95.5 or 100).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTestResult.Focus();
                txtTestResult.SelectAll();
                return false;
            }

            if (result < 0)
            {
                MessageBox.Show("Test result cannot be negative. Please enter a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTestResult.Focus();
                txtTestResult.SelectAll();
                return false;
            }

            if (result > 10000)
            {
                MessageBox.Show("Test result seems unusually high. Please verify the value is correct.", "Validation Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (MessageBox.Show("Continue with this value?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    txtTestResult.Focus();
                    return false;
                }
            }

            return true;
        }

        private async Task<TestDto?> CheckForDuplicateTestAsync(int patientId, string testName, int excludeId = 0)
        {
            try
            {
                var tests = await _testService.GetTestsByPatientIdAsync(patientId);
                var existingTest = tests.FirstOrDefault(t =>
                    t.TestName.Equals(testName, StringComparison.OrdinalIgnoreCase) &&
                    (excludeId == 0 || t.Id != excludeId));
                return existingTest;
            }
            catch
            {
                return null;
            }
        }

        private async Task RefreshTestsGridAsync(int patientId = 0)
        {
            try
            {
                int idToUse = patientId > 0 ? patientId :
                             lastSelectedTestPatientId > 0 ? lastSelectedTestPatientId :
                             (cmbTestPatient.SelectedValue != null && (int)cmbTestPatient.SelectedValue > 0 ? (int)cmbTestPatient.SelectedValue : 0);

                if (idToUse > 0)
                {
                    var tests = await _testService.GetTestsByPatientIdAsync(idToUse);
                    testBindingSource.DataSource = tests.ToList();

                    isUpdatingComboBox = true;
                    try
                    {
                        cmbTestPatient.SelectedValue = idToUse;
                    }
                    finally
                    {
                        isUpdatingComboBox = false;
                    }

                    HideUnwantedColumns();
                }
                else
                {
                    testBindingSource.DataSource = new List<TestDto>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing tests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("From Date cannot be greater than To Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                    saveFileDialog.FileName = $"PatientReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    saveFileDialog.DefaultExt = ".csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var dataTable = await _reportService.GetReportDataAsync(fromDate, toDate);

                        if (dataTable == null || dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No data found for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        ExportToCsv(dataTable, saveFileDialog.FileName);
                        MessageBox.Show($"Report generated successfully:\n{saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCsv(DataTable dataTable, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                var headers = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
                writer.WriteLine(string.Join(",", headers));

                foreach (DataRow row in dataTable.Rows)
                {
                    var values = row.ItemArray.Select(v => $"\"{v}\"").ToArray();
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }
    }
}
