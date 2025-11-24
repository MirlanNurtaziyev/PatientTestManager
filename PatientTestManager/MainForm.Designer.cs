namespace PatientTestManager.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblPatientsTitle;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.GroupBox gbPatientInput;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientDOB;
        private System.Windows.Forms.DateTimePicker dtpPatientDOB;
        private System.Windows.Forms.Label lblPatientGender;
        private System.Windows.Forms.ComboBox cmbPatientGender;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnUpdatePatient;
        private System.Windows.Forms.Button btnDeletePatient;
        private System.Windows.Forms.Button btnClearPatient;

        private System.Windows.Forms.Label lblTestsTitle;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.GroupBox gbTestInput;
        private System.Windows.Forms.Label lblTestPatient;
        private System.Windows.Forms.ComboBox cmbTestPatient;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label lblTestDate;
        private System.Windows.Forms.DateTimePicker dtpTestDate;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.Label lblTestThreshold;
        private System.Windows.Forms.CheckBox chkTestThreshold;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnUpdateTest;
        private System.Windows.Forms.Button btnDeleteTest;
        private System.Windows.Forms.Button btnClearTest;

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TableLayoutPanel tlpPatients;
        private System.Windows.Forms.TableLayoutPanel tlpTests;
        private System.Windows.Forms.TableLayoutPanel tlpPatientInput;
        private System.Windows.Forms.TableLayoutPanel tlpTestInput;
        private System.Windows.Forms.FlowLayoutPanel flpPatientButtons;
        private System.Windows.Forms.FlowLayoutPanel flpTestButtons;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TableLayoutPanel tlpReportFilters;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            pnlLeft = new Panel();
            tlpPatients = new TableLayoutPanel();
            lblPatientsTitle = new Label();
            dgvPatients = new DataGridView();
            gbPatientInput = new GroupBox();
            tlpPatientInput = new TableLayoutPanel();
            lblPatientName = new Label();
            txtPatientName = new TextBox();
            lblPatientDOB = new Label();
            dtpPatientDOB = new DateTimePicker();
            lblPatientGender = new Label();
            cmbPatientGender = new ComboBox();
            flpPatientButtons = new FlowLayoutPanel();
            btnAddPatient = new Button();
            btnUpdatePatient = new Button();
            btnDeletePatient = new Button();
            btnClearPatient = new Button();
            pnlRight = new Panel();
            tlpTests = new TableLayoutPanel();
            lblTestsTitle = new Label();
            dgvTests = new DataGridView();
            gbTestInput = new GroupBox();
            tlpTestInput = new TableLayoutPanel();
            lblTestPatient = new Label();
            cmbTestPatient = new ComboBox();
            lblTestName = new Label();
            txtTestName = new TextBox();
            lblTestDate = new Label();
            dtpTestDate = new DateTimePicker();
            lblTestResult = new Label();
            txtTestResult = new TextBox();
            lblTestThreshold = new Label();
            chkTestThreshold = new CheckBox();
            flpTestButtons = new FlowLayoutPanel();
            btnAddTest = new Button();
            btnUpdateTest = new Button();
            btnDeleteTest = new Button();
            btnClearTest = new Button();
            tlpReportFilters = new TableLayoutPanel();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnGenerateReport = new Button();
            tlpMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            tlpPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            gbPatientInput.SuspendLayout();
            tlpPatientInput.SuspendLayout();
            flpPatientButtons.SuspendLayout();
            pnlRight.SuspendLayout();
            tlpTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTests).BeginInit();
            gbTestInput.SuspendLayout();
            tlpTestInput.SuspendLayout();
            flpTestButtons.SuspendLayout();
            tlpReportFilters.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(pnlLeft, 0, 0);
            tlpMain.Controls.Add(pnlRight, 1, 0);
            tlpMain.Controls.Add(tlpReportFilters, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(10);
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpMain.Size = new Size(1200, 750);
            tlpMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(tlpPatients);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(13, 13);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(584, 664);
            pnlLeft.TabIndex = 0;
            // 
            // tlpPatients
            // 
            tlpPatients.ColumnCount = 1;
            tlpPatients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPatients.Controls.Add(lblPatientsTitle, 0, 0);
            tlpPatients.Controls.Add(dgvPatients, 0, 1);
            tlpPatients.Controls.Add(gbPatientInput, 0, 2);
            tlpPatients.Dock = DockStyle.Fill;
            tlpPatients.Location = new Point(0, 0);
            tlpPatients.Name = "tlpPatients";
            tlpPatients.Padding = new Padding(5);
            tlpPatients.RowCount = 3;
            tlpPatients.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpPatients.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPatients.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tlpPatients.Size = new Size(582, 662);
            tlpPatients.TabIndex = 0;
            // 
            // lblPatientsTitle
            // 
            lblPatientsTitle.AutoSize = true;
            lblPatientsTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblPatientsTitle.Location = new Point(8, 5);
            lblPatientsTitle.Name = "lblPatientsTitle";
            lblPatientsTitle.Size = new Size(64, 16);
            lblPatientsTitle.TabIndex = 0;
            lblPatientsTitle.Text = "Patients";
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BorderStyle = BorderStyle.Fixed3D;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Dock = DockStyle.Fill;
            dgvPatients.Location = new Point(8, 38);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(566, 416);
            dgvPatients.TabIndex = 1;
            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
            // 
            // gbPatientInput
            // 
            gbPatientInput.Controls.Add(tlpPatientInput);
            gbPatientInput.Dock = DockStyle.Fill;
            gbPatientInput.Location = new Point(8, 460);
            gbPatientInput.Name = "gbPatientInput";
            gbPatientInput.Padding = new Padding(10);
            gbPatientInput.Size = new Size(566, 194);
            gbPatientInput.TabIndex = 2;
            gbPatientInput.TabStop = false;
            gbPatientInput.Text = "Add/Edit Patient";
            // 
            // tlpPatientInput
            // 
            tlpPatientInput.ColumnCount = 2;
            tlpPatientInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpPatientInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPatientInput.Controls.Add(lblPatientName, 0, 0);
            tlpPatientInput.Controls.Add(txtPatientName, 1, 0);
            tlpPatientInput.Controls.Add(lblPatientDOB, 0, 1);
            tlpPatientInput.Controls.Add(dtpPatientDOB, 1, 1);
            tlpPatientInput.Controls.Add(lblPatientGender, 0, 2);
            tlpPatientInput.Controls.Add(cmbPatientGender, 1, 2);
            tlpPatientInput.Controls.Add(flpPatientButtons, 0, 3);
            tlpPatientInput.Dock = DockStyle.Fill;
            tlpPatientInput.Location = new Point(10, 26);
            tlpPatientInput.Name = "tlpPatientInput";
            tlpPatientInput.RowCount = 4;
            tlpPatientInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpPatientInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpPatientInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpPatientInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPatientInput.Size = new Size(546, 158);
            tlpPatientInput.TabIndex = 0;
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Left;
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(3, 7);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(42, 15);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Name:";
            // 
            // txtPatientName
            // 
            txtPatientName.Dock = DockStyle.Fill;
            txtPatientName.Location = new Point(103, 3);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(440, 23);
            txtPatientName.TabIndex = 1;
            // 
            // lblPatientDOB
            // 
            lblPatientDOB.Anchor = AnchorStyles.Left;
            lblPatientDOB.AutoSize = true;
            lblPatientDOB.Location = new Point(3, 37);
            lblPatientDOB.Name = "lblPatientDOB";
            lblPatientDOB.Size = new Size(34, 15);
            lblPatientDOB.TabIndex = 2;
            lblPatientDOB.Text = "DOB:";
            // 
            // dtpPatientDOB
            // 
            dtpPatientDOB.Dock = DockStyle.Fill;
            dtpPatientDOB.Format = DateTimePickerFormat.Short;
            dtpPatientDOB.Location = new Point(103, 33);
            dtpPatientDOB.Name = "dtpPatientDOB";
            dtpPatientDOB.Size = new Size(440, 23);
            dtpPatientDOB.TabIndex = 3;
            // 
            // lblPatientGender
            // 
            lblPatientGender.Anchor = AnchorStyles.Left;
            lblPatientGender.AutoSize = true;
            lblPatientGender.Location = new Point(3, 67);
            lblPatientGender.Name = "lblPatientGender";
            lblPatientGender.Size = new Size(48, 15);
            lblPatientGender.TabIndex = 4;
            lblPatientGender.Text = "Gender:";
            // 
            // cmbPatientGender
            // 
            cmbPatientGender.Dock = DockStyle.Fill;
            cmbPatientGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatientGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbPatientGender.Location = new Point(103, 63);
            cmbPatientGender.Name = "cmbPatientGender";
            cmbPatientGender.Size = new Size(440, 23);
            cmbPatientGender.TabIndex = 5;
            // 
            // flpPatientButtons
            // 
            flpPatientButtons.AutoSize = true;
            tlpPatientInput.SetColumnSpan(flpPatientButtons, 2);
            flpPatientButtons.Controls.Add(btnAddPatient);
            flpPatientButtons.Controls.Add(btnUpdatePatient);
            flpPatientButtons.Controls.Add(btnDeletePatient);
            flpPatientButtons.Controls.Add(btnClearPatient);
            flpPatientButtons.Dock = DockStyle.Fill;
            flpPatientButtons.Location = new Point(3, 93);
            flpPatientButtons.Name = "flpPatientButtons";
            flpPatientButtons.Size = new Size(540, 62);
            flpPatientButtons.TabIndex = 6;
            // 
            // btnAddPatient
            // 
            btnAddPatient.AutoSize = true;
            btnAddPatient.Location = new Point(3, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(75, 25);
            btnAddPatient.TabIndex = 0;
            btnAddPatient.Text = "Add";
            btnAddPatient.Click += BtnAddPatient_Click;
            // 
            // btnUpdatePatient
            // 
            btnUpdatePatient.AutoSize = true;
            btnUpdatePatient.Location = new Point(84, 3);
            btnUpdatePatient.Name = "btnUpdatePatient";
            btnUpdatePatient.Size = new Size(75, 25);
            btnUpdatePatient.TabIndex = 1;
            btnUpdatePatient.Text = "Update";
            btnUpdatePatient.Click += BtnUpdatePatient_Click;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.AutoSize = true;
            btnDeletePatient.Location = new Point(165, 3);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(75, 25);
            btnDeletePatient.TabIndex = 2;
            btnDeletePatient.Text = "Delete";
            btnDeletePatient.Click += BtnDeletePatient_Click;
            // 
            // btnClearPatient
            // 
            btnClearPatient.AutoSize = true;
            btnClearPatient.Location = new Point(246, 3);
            btnClearPatient.Name = "btnClearPatient";
            btnClearPatient.Size = new Size(75, 25);
            btnClearPatient.TabIndex = 3;
            btnClearPatient.Text = "Clear";
            btnClearPatient.Click += BtnClearPatient_Click;
            // 
            // pnlRight
            // 
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(tlpTests);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(603, 13);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(584, 664);
            pnlRight.TabIndex = 1;
            // 
            // tlpTests
            // 
            tlpTests.ColumnCount = 1;
            tlpTests.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTests.Controls.Add(lblTestsTitle, 0, 0);
            tlpTests.Controls.Add(dgvTests, 0, 1);
            tlpTests.Controls.Add(gbTestInput, 0, 2);
            tlpTests.Dock = DockStyle.Fill;
            tlpTests.Location = new Point(0, 0);
            tlpTests.Name = "tlpTests";
            tlpTests.Padding = new Padding(5);
            tlpTests.RowCount = 3;
            tlpTests.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTests.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTests.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            tlpTests.Size = new Size(582, 662);
            tlpTests.TabIndex = 0;
            // 
            // lblTestsTitle
            // 
            lblTestsTitle.AutoSize = true;
            lblTestsTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblTestsTitle.Location = new Point(8, 5);
            lblTestsTitle.Name = "lblTestsTitle";
            lblTestsTitle.Size = new Size(44, 16);
            lblTestsTitle.TabIndex = 0;
            lblTestsTitle.Text = "Tests";
            // 
            // dgvTests
            // 
            dgvTests.AllowUserToAddRows = false;
            dgvTests.AllowUserToDeleteRows = false;
            dgvTests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTests.BorderStyle = BorderStyle.Fixed3D;
            dgvTests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTests.Dock = DockStyle.Fill;
            dgvTests.Location = new Point(8, 38);
            dgvTests.MultiSelect = false;
            dgvTests.Name = "dgvTests";
            dgvTests.ReadOnly = true;
            dgvTests.RowHeadersWidth = 51;
            dgvTests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTests.Size = new Size(566, 366);
            dgvTests.TabIndex = 1;
            dgvTests.SelectionChanged += DgvTests_SelectionChanged;
            // 
            // gbTestInput
            // 
            gbTestInput.Controls.Add(tlpTestInput);
            gbTestInput.Dock = DockStyle.Fill;
            gbTestInput.Location = new Point(8, 410);
            gbTestInput.Name = "gbTestInput";
            gbTestInput.Padding = new Padding(10);
            gbTestInput.Size = new Size(566, 244);
            gbTestInput.TabIndex = 2;
            gbTestInput.TabStop = false;
            gbTestInput.Text = "Add/Edit Test";
            // 
            // tlpTestInput
            // 
            tlpTestInput.ColumnCount = 2;
            tlpTestInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpTestInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTestInput.Controls.Add(lblTestPatient, 0, 0);
            tlpTestInput.Controls.Add(cmbTestPatient, 1, 0);
            tlpTestInput.Controls.Add(lblTestName, 0, 1);
            tlpTestInput.Controls.Add(txtTestName, 1, 1);
            tlpTestInput.Controls.Add(lblTestDate, 0, 2);
            tlpTestInput.Controls.Add(dtpTestDate, 1, 2);
            tlpTestInput.Controls.Add(lblTestResult, 0, 3);
            tlpTestInput.Controls.Add(txtTestResult, 1, 3);
            tlpTestInput.Controls.Add(lblTestThreshold, 0, 4);
            tlpTestInput.Controls.Add(chkTestThreshold, 1, 4);
            tlpTestInput.Controls.Add(flpTestButtons, 0, 5);
            tlpTestInput.Dock = DockStyle.Fill;
            tlpTestInput.Location = new Point(10, 26);
            tlpTestInput.Name = "tlpTestInput";
            tlpTestInput.RowCount = 6;
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTestInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTestInput.Size = new Size(546, 208);
            tlpTestInput.TabIndex = 0;
            // 
            // lblTestPatient
            // 
            lblTestPatient.Anchor = AnchorStyles.Left;
            lblTestPatient.AutoSize = true;
            lblTestPatient.Location = new Point(3, 7);
            lblTestPatient.Name = "lblTestPatient";
            lblTestPatient.Size = new Size(47, 15);
            lblTestPatient.TabIndex = 0;
            lblTestPatient.Text = "Patient:";
            // 
            // cmbTestPatient
            // 
            cmbTestPatient.Dock = DockStyle.Fill;
            cmbTestPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTestPatient.Location = new Point(123, 3);
            cmbTestPatient.Name = "cmbTestPatient";
            cmbTestPatient.Size = new Size(420, 23);
            cmbTestPatient.TabIndex = 1;
            cmbTestPatient.SelectedIndexChanged += CmbTestPatient_SelectedIndexChanged;
            // 
            // lblTestName
            // 
            lblTestName.Anchor = AnchorStyles.Left;
            lblTestName.AutoSize = true;
            lblTestName.Location = new Point(3, 37);
            lblTestName.Name = "lblTestName";
            lblTestName.Size = new Size(66, 15);
            lblTestName.TabIndex = 2;
            lblTestName.Text = "Test Name:";
            // 
            // txtTestName
            // 
            txtTestName.Dock = DockStyle.Fill;
            txtTestName.Location = new Point(123, 33);
            txtTestName.Name = "txtTestName";
            txtTestName.Size = new Size(420, 23);
            txtTestName.TabIndex = 3;
            // 
            // lblTestDate
            // 
            lblTestDate.Anchor = AnchorStyles.Left;
            lblTestDate.AutoSize = true;
            lblTestDate.Location = new Point(3, 67);
            lblTestDate.Name = "lblTestDate";
            lblTestDate.Size = new Size(58, 15);
            lblTestDate.TabIndex = 4;
            lblTestDate.Text = "Test Date:";
            // 
            // dtpTestDate
            // 
            dtpTestDate.Dock = DockStyle.Fill;
            dtpTestDate.Format = DateTimePickerFormat.Short;
            dtpTestDate.Location = new Point(123, 63);
            dtpTestDate.Name = "dtpTestDate";
            dtpTestDate.Size = new Size(420, 23);
            dtpTestDate.TabIndex = 5;
            // 
            // lblTestResult
            // 
            lblTestResult.Anchor = AnchorStyles.Left;
            lblTestResult.AutoSize = true;
            lblTestResult.Location = new Point(3, 97);
            lblTestResult.Name = "lblTestResult";
            lblTestResult.Size = new Size(42, 15);
            lblTestResult.TabIndex = 6;
            lblTestResult.Text = "Result:";
            // 
            // txtTestResult
            // 
            txtTestResult.Dock = DockStyle.Fill;
            txtTestResult.Location = new Point(123, 93);
            txtTestResult.Name = "txtTestResult";
            txtTestResult.Size = new Size(420, 23);
            txtTestResult.TabIndex = 7;
            // 
            // lblTestThreshold
            // 
            lblTestThreshold.Anchor = AnchorStyles.Left;
            lblTestThreshold.AutoSize = true;
            lblTestThreshold.Location = new Point(3, 127);
            lblTestThreshold.Name = "lblTestThreshold";
            lblTestThreshold.Size = new Size(101, 15);
            lblTestThreshold.TabIndex = 8;
            lblTestThreshold.Text = "Within Threshold:";
            // 
            // chkTestThreshold
            // 
            chkTestThreshold.Anchor = AnchorStyles.Left;
            chkTestThreshold.Location = new Point(123, 123);
            chkTestThreshold.Name = "chkTestThreshold";
            chkTestThreshold.Size = new Size(104, 24);
            chkTestThreshold.TabIndex = 9;
            // 
            // flpTestButtons
            // 
            flpTestButtons.AutoSize = true;
            tlpTestInput.SetColumnSpan(flpTestButtons, 2);
            flpTestButtons.Controls.Add(btnAddTest);
            flpTestButtons.Controls.Add(btnUpdateTest);
            flpTestButtons.Controls.Add(btnDeleteTest);
            flpTestButtons.Controls.Add(btnClearTest);
            flpTestButtons.Dock = DockStyle.Fill;
            flpTestButtons.Location = new Point(3, 153);
            flpTestButtons.Name = "flpTestButtons";
            flpTestButtons.Size = new Size(540, 52);
            flpTestButtons.TabIndex = 10;
            // 
            // btnAddTest
            // 
            btnAddTest.AutoSize = true;
            btnAddTest.Location = new Point(3, 3);
            btnAddTest.Name = "btnAddTest";
            btnAddTest.Size = new Size(75, 25);
            btnAddTest.TabIndex = 0;
            btnAddTest.Text = "Add";
            btnAddTest.Click += BtnAddTest_Click;
            // 
            // btnUpdateTest
            // 
            btnUpdateTest.AutoSize = true;
            btnUpdateTest.Location = new Point(84, 3);
            btnUpdateTest.Name = "btnUpdateTest";
            btnUpdateTest.Size = new Size(75, 25);
            btnUpdateTest.TabIndex = 1;
            btnUpdateTest.Text = "Update";
            btnUpdateTest.Click += BtnUpdateTest_Click;
            // 
            // btnDeleteTest
            // 
            btnDeleteTest.AutoSize = true;
            btnDeleteTest.Location = new Point(165, 3);
            btnDeleteTest.Name = "btnDeleteTest";
            btnDeleteTest.Size = new Size(75, 25);
            btnDeleteTest.TabIndex = 2;
            btnDeleteTest.Text = "Delete";
            btnDeleteTest.Click += BtnDeleteTest_Click;
            // 
            // btnClearTest
            // 
            btnClearTest.AutoSize = true;
            btnClearTest.Location = new Point(246, 3);
            btnClearTest.Name = "btnClearTest";
            btnClearTest.Size = new Size(75, 25);
            btnClearTest.TabIndex = 3;
            btnClearTest.Text = "Clear";
            btnClearTest.Click += BtnClearTest_Click;
            // 
            // tlpReportFilters
            // 
            tlpReportFilters.ColumnCount = 5;
            tlpReportFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpReportFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpReportFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpReportFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpReportFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpReportFilters.Controls.Add(lblFromDate, 0, 0);
            tlpReportFilters.Controls.Add(dtpFromDate, 1, 0);
            tlpReportFilters.Controls.Add(lblToDate, 2, 0);
            tlpReportFilters.Controls.Add(dtpToDate, 3, 0);
            tlpReportFilters.Controls.Add(btnGenerateReport, 4, 0);
            tlpReportFilters.Dock = DockStyle.Fill;
            tlpReportFilters.Location = new Point(13, 683);
            tlpReportFilters.Name = "tlpReportFilters";
            tlpReportFilters.RowCount = 1;
            tlpReportFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpReportFilters.Size = new Size(584, 54);
            tlpReportFilters.TabIndex = 12;
            // 
            // lblFromDate
            // 
            lblFromDate.Anchor = AnchorStyles.Left;
            lblFromDate.AutoSize = true;
            lblFromDate.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblFromDate.Location = new Point(3, 19);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(68, 15);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "From Date:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Dock = DockStyle.Fill;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(103, 3);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(144, 23);
            dtpFromDate.TabIndex = 1;
            dtpFromDate.Value = new DateTime(2025, 10, 23, 11, 8, 45, 300);
            // 
            // lblToDate
            // 
            lblToDate.Anchor = AnchorStyles.Left;
            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblToDate.Location = new Point(253, 19);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(52, 15);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "To Date:";
            // 
            // dtpToDate
            // 
            dtpToDate.Dock = DockStyle.Fill;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(353, 3);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(144, 23);
            dtpToDate.TabIndex = 3;
            dtpToDate.Value = new DateTime(2025, 11, 23, 11, 8, 45, 303);
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.AutoSize = true;
            btnGenerateReport.BackColor = Color.FromArgb(0, 120, 215);
            btnGenerateReport.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(503, 3);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(78, 28);
            btnGenerateReport.TabIndex = 4;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            Controls.Add(tlpMain);
            Name = "MainForm";
            Text = "Patient Test Manager";
            tlpMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            tlpPatients.ResumeLayout(false);
            tlpPatients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            gbPatientInput.ResumeLayout(false);
            tlpPatientInput.ResumeLayout(false);
            tlpPatientInput.PerformLayout();
            flpPatientButtons.ResumeLayout(false);
            flpPatientButtons.PerformLayout();
            pnlRight.ResumeLayout(false);
            tlpTests.ResumeLayout(false);
            tlpTests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTests).EndInit();
            gbTestInput.ResumeLayout(false);
            tlpTestInput.ResumeLayout(false);
            tlpTestInput.PerformLayout();
            flpTestButtons.ResumeLayout(false);
            flpTestButtons.PerformLayout();
            tlpReportFilters.ResumeLayout(false);
            tlpReportFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}