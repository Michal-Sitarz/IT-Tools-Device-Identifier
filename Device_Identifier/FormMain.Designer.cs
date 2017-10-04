namespace Device_Identifier
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelTop = new System.Windows.Forms.Label();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Location = new System.Windows.Forms.Label();
            this.groupBox_PC = new System.Windows.Forms.GroupBox();
            this.lblSide_Match = new System.Windows.Forms.Label();
            this.lblBot_Match = new System.Windows.Forms.Label();
            this.lblTop_Match = new System.Windows.Forms.Label();
            this.textBox_ComputerName = new System.Windows.Forms.TextBox();
            this.textBox_SerialNumber = new System.Windows.Forms.TextBox();
            this.textBox_Model = new System.Windows.Forms.TextBox();
            this.textBox_Manufacturer = new System.Windows.Forms.TextBox();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.textBox_OSversion = new System.Windows.Forms.TextBox();
            this.label_ComputerName = new System.Windows.Forms.Label();
            this.label_SerialNumber = new System.Windows.Forms.Label();
            this.label_Model = new System.Windows.Forms.Label();
            this.label_Manufacturer = new System.Windows.Forms.Label();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_OSversion = new System.Windows.Forms.Label();
            this.groupBox_User = new System.Windows.Forms.GroupBox();
            this.box_locationPos = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.box_locationZone = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_Department = new System.Windows.Forms.Label();
            this.groupBox_PCspecs = new System.Windows.Forms.GroupBox();
            this.textBox_HDDtype = new System.Windows.Forms.TextBox();
            this.textBox_HDDcapacity = new System.Windows.Forms.TextBox();
            this.textBox_RAMmoduleDetails = new System.Windows.Forms.TextBox();
            this.textBox_RAMcapabilities = new System.Windows.Forms.TextBox();
            this.textBox_RAMinstalled = new System.Windows.Forms.TextBox();
            this.textBox_CPU = new System.Windows.Forms.TextBox();
            this.label_HDDtype = new System.Windows.Forms.Label();
            this.label_HDDcapacity = new System.Windows.Forms.Label();
            this.label_RAMmoduleDetails = new System.Windows.Forms.Label();
            this.label_RAMcapabilities = new System.Windows.Forms.Label();
            this.label_RAMinstalled = new System.Windows.Forms.Label();
            this.label_CPU = new System.Windows.Forms.Label();
            this.groupBox_Peripherals = new System.Windows.Forms.GroupBox();
            this.checkBox_TPM_BitLocker = new System.Windows.Forms.CheckBox();
            this.label_TPM_BitLocker = new System.Windows.Forms.Label();
            this.numericBox_MonitorsConnected = new System.Windows.Forms.NumericUpDown();
            this.comboBox_InputDevices = new System.Windows.Forms.ComboBox();
            this.textBox_MonitorsConnected = new System.Windows.Forms.TextBox();
            this.checkBox_DockingStation = new System.Windows.Forms.CheckBox();
            this.label_MonitorsConnected = new System.Windows.Forms.Label();
            this.label_InputDevices = new System.Windows.Forms.Label();
            this.label_DockingStation = new System.Windows.Forms.Label();
            this.btn_ReadSpecs = new System.Windows.Forms.Button();
            this.btn_SaveToDB = new System.Windows.Forms.Button();
            this.groupBox_PC.SuspendLayout();
            this.groupBox_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_locationPos)).BeginInit();
            this.groupBox_PCspecs.SuspendLayout();
            this.groupBox_Peripherals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox_MonitorsConnected)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTop.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTop.Location = new System.Drawing.Point(332, 29);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(288, 32);
            this.labelTop.TabIndex = 0;
            this.labelTop.Text = "D e v i c e   I d e n t i f i e r";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.ForeColor = System.Drawing.Color.White;
            this.label_Username.Location = new System.Drawing.Point(19, 28);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(58, 13);
            this.label_Username.TabIndex = 0;
            this.label_Username.Text = "Username:";
            // 
            // label_Location
            // 
            this.label_Location.AutoSize = true;
            this.label_Location.ForeColor = System.Drawing.Color.White;
            this.label_Location.Location = new System.Drawing.Point(20, 54);
            this.label_Location.Name = "label_Location";
            this.label_Location.Size = new System.Drawing.Size(51, 13);
            this.label_Location.TabIndex = 3;
            this.label_Location.Text = "Location:";
            // 
            // groupBox_PC
            // 
            this.groupBox_PC.Controls.Add(this.lblSide_Match);
            this.groupBox_PC.Controls.Add(this.lblBot_Match);
            this.groupBox_PC.Controls.Add(this.lblTop_Match);
            this.groupBox_PC.Controls.Add(this.textBox_ComputerName);
            this.groupBox_PC.Controls.Add(this.textBox_SerialNumber);
            this.groupBox_PC.Controls.Add(this.textBox_Model);
            this.groupBox_PC.Controls.Add(this.textBox_Manufacturer);
            this.groupBox_PC.Controls.Add(this.textBox_Type);
            this.groupBox_PC.Controls.Add(this.textBox_OSversion);
            this.groupBox_PC.Controls.Add(this.label_ComputerName);
            this.groupBox_PC.Controls.Add(this.label_SerialNumber);
            this.groupBox_PC.Controls.Add(this.label_Model);
            this.groupBox_PC.Controls.Add(this.label_Manufacturer);
            this.groupBox_PC.Controls.Add(this.label_Type);
            this.groupBox_PC.Controls.Add(this.label_OSversion);
            this.groupBox_PC.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_PC.Location = new System.Drawing.Point(72, 87);
            this.groupBox_PC.Name = "groupBox_PC";
            this.groupBox_PC.Size = new System.Drawing.Size(384, 190);
            this.groupBox_PC.TabIndex = 59;
            this.groupBox_PC.TabStop = false;
            this.groupBox_PC.Text = "PC:";
            // 
            // lblSide_Match
            // 
            this.lblSide_Match.BackColor = System.Drawing.Color.White;
            this.lblSide_Match.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSide_Match.Location = new System.Drawing.Point(279, 136);
            this.lblSide_Match.Name = "lblSide_Match";
            this.lblSide_Match.Size = new System.Drawing.Size(5, 31);
            this.lblSide_Match.TabIndex = 16;
            // 
            // lblBot_Match
            // 
            this.lblBot_Match.BackColor = System.Drawing.Color.White;
            this.lblBot_Match.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBot_Match.Location = new System.Drawing.Point(272, 162);
            this.lblBot_Match.Name = "lblBot_Match";
            this.lblBot_Match.Size = new System.Drawing.Size(12, 5);
            this.lblBot_Match.TabIndex = 15;
            // 
            // lblTop_Match
            // 
            this.lblTop_Match.BackColor = System.Drawing.Color.White;
            this.lblTop_Match.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTop_Match.Location = new System.Drawing.Point(272, 136);
            this.lblTop_Match.Name = "lblTop_Match";
            this.lblTop_Match.Size = new System.Drawing.Size(12, 5);
            this.lblTop_Match.TabIndex = 14;
            // 
            // textBox_ComputerName
            // 
            this.textBox_ComputerName.BackColor = System.Drawing.Color.LightGray;
            this.textBox_ComputerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ComputerName.Location = new System.Drawing.Point(114, 154);
            this.textBox_ComputerName.Name = "textBox_ComputerName";
            this.textBox_ComputerName.ReadOnly = true;
            this.textBox_ComputerName.Size = new System.Drawing.Size(154, 20);
            this.textBox_ComputerName.TabIndex = 13;
            this.textBox_ComputerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_SerialNumber
            // 
            this.textBox_SerialNumber.BackColor = System.Drawing.Color.LightGray;
            this.textBox_SerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SerialNumber.Location = new System.Drawing.Point(114, 128);
            this.textBox_SerialNumber.Name = "textBox_SerialNumber";
            this.textBox_SerialNumber.ReadOnly = true;
            this.textBox_SerialNumber.Size = new System.Drawing.Size(154, 20);
            this.textBox_SerialNumber.TabIndex = 12;
            this.textBox_SerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Model
            // 
            this.textBox_Model.BackColor = System.Drawing.Color.LightGray;
            this.textBox_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Model.Location = new System.Drawing.Point(114, 102);
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.ReadOnly = true;
            this.textBox_Model.Size = new System.Drawing.Size(252, 20);
            this.textBox_Model.TabIndex = 11;
            this.textBox_Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Manufacturer
            // 
            this.textBox_Manufacturer.BackColor = System.Drawing.Color.LightGray;
            this.textBox_Manufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Manufacturer.Location = new System.Drawing.Point(114, 76);
            this.textBox_Manufacturer.Name = "textBox_Manufacturer";
            this.textBox_Manufacturer.ReadOnly = true;
            this.textBox_Manufacturer.Size = new System.Drawing.Size(252, 20);
            this.textBox_Manufacturer.TabIndex = 10;
            this.textBox_Manufacturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Type
            // 
            this.textBox_Type.BackColor = System.Drawing.Color.LightGray;
            this.textBox_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Type.Location = new System.Drawing.Point(114, 50);
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(252, 20);
            this.textBox_Type.TabIndex = 29;
            this.textBox_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_OSversion
            // 
            this.textBox_OSversion.BackColor = System.Drawing.Color.LightGray;
            this.textBox_OSversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_OSversion.Location = new System.Drawing.Point(114, 24);
            this.textBox_OSversion.Name = "textBox_OSversion";
            this.textBox_OSversion.ReadOnly = true;
            this.textBox_OSversion.Size = new System.Drawing.Size(252, 20);
            this.textBox_OSversion.TabIndex = 28;
            this.textBox_OSversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ComputerName
            // 
            this.label_ComputerName.AutoSize = true;
            this.label_ComputerName.ForeColor = System.Drawing.Color.White;
            this.label_ComputerName.Location = new System.Drawing.Point(19, 157);
            this.label_ComputerName.Name = "label_ComputerName";
            this.label_ComputerName.Size = new System.Drawing.Size(86, 13);
            this.label_ComputerName.TabIndex = 7;
            this.label_ComputerName.Text = "Computer Name:";
            // 
            // label_SerialNumber
            // 
            this.label_SerialNumber.AutoSize = true;
            this.label_SerialNumber.ForeColor = System.Drawing.Color.White;
            this.label_SerialNumber.Location = new System.Drawing.Point(19, 131);
            this.label_SerialNumber.Name = "label_SerialNumber";
            this.label_SerialNumber.Size = new System.Drawing.Size(76, 13);
            this.label_SerialNumber.TabIndex = 6;
            this.label_SerialNumber.Text = "Serial Number:";
            // 
            // label_Model
            // 
            this.label_Model.AutoSize = true;
            this.label_Model.ForeColor = System.Drawing.Color.White;
            this.label_Model.Location = new System.Drawing.Point(19, 105);
            this.label_Model.Name = "label_Model";
            this.label_Model.Size = new System.Drawing.Size(39, 13);
            this.label_Model.TabIndex = 5;
            this.label_Model.Text = "Model:";
            // 
            // label_Manufacturer
            // 
            this.label_Manufacturer.AutoSize = true;
            this.label_Manufacturer.ForeColor = System.Drawing.Color.White;
            this.label_Manufacturer.Location = new System.Drawing.Point(19, 79);
            this.label_Manufacturer.Name = "label_Manufacturer";
            this.label_Manufacturer.Size = new System.Drawing.Size(73, 13);
            this.label_Manufacturer.TabIndex = 4;
            this.label_Manufacturer.Text = "Manufacturer:";
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.ForeColor = System.Drawing.Color.White;
            this.label_Type.Location = new System.Drawing.Point(19, 53);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(34, 13);
            this.label_Type.TabIndex = 3;
            this.label_Type.Text = "Type:";
            // 
            // label_OSversion
            // 
            this.label_OSversion.AutoSize = true;
            this.label_OSversion.ForeColor = System.Drawing.Color.White;
            this.label_OSversion.Location = new System.Drawing.Point(19, 27);
            this.label_OSversion.Name = "label_OSversion";
            this.label_OSversion.Size = new System.Drawing.Size(62, 13);
            this.label_OSversion.TabIndex = 2;
            this.label_OSversion.Text = "OS version:";
            // 
            // groupBox_User
            // 
            this.groupBox_User.Controls.Add(this.box_locationPos);
            this.groupBox_User.Controls.Add(this.comboBox_Department);
            this.groupBox_User.Controls.Add(this.box_locationZone);
            this.groupBox_User.Controls.Add(this.textBox_Username);
            this.groupBox_User.Controls.Add(this.label_Department);
            this.groupBox_User.Controls.Add(this.label_Username);
            this.groupBox_User.Controls.Add(this.label_Location);
            this.groupBox_User.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_User.Location = new System.Drawing.Point(479, 87);
            this.groupBox_User.Name = "groupBox_User";
            this.groupBox_User.Size = new System.Drawing.Size(384, 118);
            this.groupBox_User.TabIndex = 0;
            this.groupBox_User.TabStop = false;
            this.groupBox_User.Text = "User:";
            // 
            // box_locationPos
            // 
            this.box_locationPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_locationPos.Location = new System.Drawing.Point(147, 51);
            this.box_locationPos.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.box_locationPos.Name = "box_locationPos";
            this.box_locationPos.Size = new System.Drawing.Size(41, 20);
            this.box_locationPos.TabIndex = 3;
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(103, 77);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(196, 21);
            this.comboBox_Department.TabIndex = 4;
            // 
            // box_locationZone
            // 
            this.box_locationZone.BackColor = System.Drawing.Color.White;
            this.box_locationZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_locationZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.box_locationZone.Location = new System.Drawing.Point(103, 51);
            this.box_locationZone.Name = "box_locationZone";
            this.box_locationZone.Size = new System.Drawing.Size(38, 20);
            this.box_locationZone.TabIndex = 2;
            this.box_locationZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Username
            // 
            this.textBox_Username.BackColor = System.Drawing.Color.White;
            this.textBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Username.Location = new System.Drawing.Point(103, 25);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(264, 20);
            this.textBox_Username.TabIndex = 1;
            this.textBox_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.ForeColor = System.Drawing.Color.White;
            this.label_Department.Location = new System.Drawing.Point(20, 80);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(65, 13);
            this.label_Department.TabIndex = 4;
            this.label_Department.Text = "Department:";
            // 
            // groupBox_PCspecs
            // 
            this.groupBox_PCspecs.Controls.Add(this.textBox_HDDtype);
            this.groupBox_PCspecs.Controls.Add(this.textBox_HDDcapacity);
            this.groupBox_PCspecs.Controls.Add(this.textBox_RAMmoduleDetails);
            this.groupBox_PCspecs.Controls.Add(this.textBox_RAMcapabilities);
            this.groupBox_PCspecs.Controls.Add(this.textBox_RAMinstalled);
            this.groupBox_PCspecs.Controls.Add(this.textBox_CPU);
            this.groupBox_PCspecs.Controls.Add(this.label_HDDtype);
            this.groupBox_PCspecs.Controls.Add(this.label_HDDcapacity);
            this.groupBox_PCspecs.Controls.Add(this.label_RAMmoduleDetails);
            this.groupBox_PCspecs.Controls.Add(this.label_RAMcapabilities);
            this.groupBox_PCspecs.Controls.Add(this.label_RAMinstalled);
            this.groupBox_PCspecs.Controls.Add(this.label_CPU);
            this.groupBox_PCspecs.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_PCspecs.Location = new System.Drawing.Point(72, 296);
            this.groupBox_PCspecs.Name = "groupBox_PCspecs";
            this.groupBox_PCspecs.Size = new System.Drawing.Size(384, 185);
            this.groupBox_PCspecs.TabIndex = 88;
            this.groupBox_PCspecs.TabStop = false;
            this.groupBox_PCspecs.Text = "PC Specs:";
            // 
            // textBox_HDDtype
            // 
            this.textBox_HDDtype.BackColor = System.Drawing.Color.LightGray;
            this.textBox_HDDtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_HDDtype.Location = new System.Drawing.Point(170, 125);
            this.textBox_HDDtype.Name = "textBox_HDDtype";
            this.textBox_HDDtype.ReadOnly = true;
            this.textBox_HDDtype.Size = new System.Drawing.Size(196, 20);
            this.textBox_HDDtype.TabIndex = 48;
            this.textBox_HDDtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_HDDcapacity
            // 
            this.textBox_HDDcapacity.BackColor = System.Drawing.Color.LightGray;
            this.textBox_HDDcapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_HDDcapacity.Location = new System.Drawing.Point(170, 151);
            this.textBox_HDDcapacity.Name = "textBox_HDDcapacity";
            this.textBox_HDDcapacity.ReadOnly = true;
            this.textBox_HDDcapacity.Size = new System.Drawing.Size(196, 20);
            this.textBox_HDDcapacity.TabIndex = 49;
            this.textBox_HDDcapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_RAMmoduleDetails
            // 
            this.textBox_RAMmoduleDetails.BackColor = System.Drawing.Color.LightGray;
            this.textBox_RAMmoduleDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RAMmoduleDetails.Location = new System.Drawing.Point(114, 47);
            this.textBox_RAMmoduleDetails.Name = "textBox_RAMmoduleDetails";
            this.textBox_RAMmoduleDetails.ReadOnly = true;
            this.textBox_RAMmoduleDetails.Size = new System.Drawing.Size(252, 20);
            this.textBox_RAMmoduleDetails.TabIndex = 45;
            this.textBox_RAMmoduleDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_RAMcapabilities
            // 
            this.textBox_RAMcapabilities.BackColor = System.Drawing.Color.LightGray;
            this.textBox_RAMcapabilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RAMcapabilities.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_RAMcapabilities.Location = new System.Drawing.Point(170, 99);
            this.textBox_RAMcapabilities.Name = "textBox_RAMcapabilities";
            this.textBox_RAMcapabilities.ReadOnly = true;
            this.textBox_RAMcapabilities.Size = new System.Drawing.Size(196, 20);
            this.textBox_RAMcapabilities.TabIndex = 47;
            this.textBox_RAMcapabilities.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_RAMinstalled
            // 
            this.textBox_RAMinstalled.BackColor = System.Drawing.Color.LightGray;
            this.textBox_RAMinstalled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RAMinstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RAMinstalled.Location = new System.Drawing.Point(170, 73);
            this.textBox_RAMinstalled.Name = "textBox_RAMinstalled";
            this.textBox_RAMinstalled.ReadOnly = true;
            this.textBox_RAMinstalled.Size = new System.Drawing.Size(196, 20);
            this.textBox_RAMinstalled.TabIndex = 46;
            this.textBox_RAMinstalled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_CPU
            // 
            this.textBox_CPU.BackColor = System.Drawing.Color.LightGray;
            this.textBox_CPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_CPU.Location = new System.Drawing.Point(114, 21);
            this.textBox_CPU.Name = "textBox_CPU";
            this.textBox_CPU.ReadOnly = true;
            this.textBox_CPU.Size = new System.Drawing.Size(252, 20);
            this.textBox_CPU.TabIndex = 44;
            this.textBox_CPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_HDDtype
            // 
            this.label_HDDtype.AutoSize = true;
            this.label_HDDtype.ForeColor = System.Drawing.Color.White;
            this.label_HDDtype.Location = new System.Drawing.Point(19, 128);
            this.label_HDDtype.Name = "label_HDDtype";
            this.label_HDDtype.Size = new System.Drawing.Size(57, 13);
            this.label_HDDtype.TabIndex = 7;
            this.label_HDDtype.Text = "HDD type:";
            // 
            // label_HDDcapacity
            // 
            this.label_HDDcapacity.AutoSize = true;
            this.label_HDDcapacity.ForeColor = System.Drawing.Color.White;
            this.label_HDDcapacity.Location = new System.Drawing.Point(19, 154);
            this.label_HDDcapacity.Name = "label_HDDcapacity";
            this.label_HDDcapacity.Size = new System.Drawing.Size(77, 13);
            this.label_HDDcapacity.TabIndex = 6;
            this.label_HDDcapacity.Text = "HDD capacity:";
            // 
            // label_RAMmoduleDetails
            // 
            this.label_RAMmoduleDetails.AutoSize = true;
            this.label_RAMmoduleDetails.ForeColor = System.Drawing.Color.White;
            this.label_RAMmoduleDetails.Location = new System.Drawing.Point(19, 50);
            this.label_RAMmoduleDetails.Name = "label_RAMmoduleDetails";
            this.label_RAMmoduleDetails.Size = new System.Drawing.Size(67, 13);
            this.label_RAMmoduleDetails.TabIndex = 5;
            this.label_RAMmoduleDetails.Text = "RAM details:";
            // 
            // label_RAMcapabilities
            // 
            this.label_RAMcapabilities.AutoSize = true;
            this.label_RAMcapabilities.ForeColor = System.Drawing.Color.White;
            this.label_RAMcapabilities.Location = new System.Drawing.Point(19, 102);
            this.label_RAMcapabilities.Name = "label_RAMcapabilities";
            this.label_RAMcapabilities.Size = new System.Drawing.Size(142, 13);
            this.label_RAMcapabilities.TabIndex = 4;
            this.label_RAMcapabilities.Text = "RAM capabilities (size/slots):";
            // 
            // label_RAMinstalled
            // 
            this.label_RAMinstalled.AutoSize = true;
            this.label_RAMinstalled.ForeColor = System.Drawing.Color.White;
            this.label_RAMinstalled.Location = new System.Drawing.Point(19, 76);
            this.label_RAMinstalled.Name = "label_RAMinstalled";
            this.label_RAMinstalled.Size = new System.Drawing.Size(128, 13);
            this.label_RAMinstalled.TabIndex = 3;
            this.label_RAMinstalled.Text = "RAM installed (size/slots):";
            // 
            // label_CPU
            // 
            this.label_CPU.AutoSize = true;
            this.label_CPU.ForeColor = System.Drawing.Color.White;
            this.label_CPU.Location = new System.Drawing.Point(19, 24);
            this.label_CPU.Name = "label_CPU";
            this.label_CPU.Size = new System.Drawing.Size(32, 13);
            this.label_CPU.TabIndex = 2;
            this.label_CPU.Text = "CPU:";
            // 
            // groupBox_Peripherals
            // 
            this.groupBox_Peripherals.Controls.Add(this.checkBox_TPM_BitLocker);
            this.groupBox_Peripherals.Controls.Add(this.label_TPM_BitLocker);
            this.groupBox_Peripherals.Controls.Add(this.numericBox_MonitorsConnected);
            this.groupBox_Peripherals.Controls.Add(this.comboBox_InputDevices);
            this.groupBox_Peripherals.Controls.Add(this.textBox_MonitorsConnected);
            this.groupBox_Peripherals.Controls.Add(this.checkBox_DockingStation);
            this.groupBox_Peripherals.Controls.Add(this.label_MonitorsConnected);
            this.groupBox_Peripherals.Controls.Add(this.label_InputDevices);
            this.groupBox_Peripherals.Controls.Add(this.label_DockingStation);
            this.groupBox_Peripherals.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_Peripherals.Location = new System.Drawing.Point(479, 296);
            this.groupBox_Peripherals.Name = "groupBox_Peripherals";
            this.groupBox_Peripherals.Size = new System.Drawing.Size(384, 112);
            this.groupBox_Peripherals.TabIndex = 1;
            this.groupBox_Peripherals.TabStop = false;
            this.groupBox_Peripherals.Text = "Peripherals:";
            // 
            // checkBox_TPM_BitLocker
            // 
            this.checkBox_TPM_BitLocker.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox_TPM_BitLocker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_TPM_BitLocker.ForeColor = System.Drawing.Color.Red;
            this.checkBox_TPM_BitLocker.Location = new System.Drawing.Point(354, 83);
            this.checkBox_TPM_BitLocker.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_TPM_BitLocker.Name = "checkBox_TPM_BitLocker";
            this.checkBox_TPM_BitLocker.Size = new System.Drawing.Size(13, 13);
            this.checkBox_TPM_BitLocker.TabIndex = 8;
            this.checkBox_TPM_BitLocker.UseVisualStyleBackColor = false;
            // 
            // label_TPM_BitLocker
            // 
            this.label_TPM_BitLocker.AutoSize = true;
            this.label_TPM_BitLocker.ForeColor = System.Drawing.Color.White;
            this.label_TPM_BitLocker.Location = new System.Drawing.Point(244, 83);
            this.label_TPM_BitLocker.Name = "label_TPM_BitLocker";
            this.label_TPM_BitLocker.Size = new System.Drawing.Size(89, 13);
            this.label_TPM_BitLocker.TabIndex = 7;
            this.label_TPM_BitLocker.Text = "TPM / BitLocker:";
            // 
            // numericBox_MonitorsConnected
            // 
            this.numericBox_MonitorsConnected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericBox_MonitorsConnected.Location = new System.Drawing.Point(328, 24);
            this.numericBox_MonitorsConnected.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericBox_MonitorsConnected.Name = "numericBox_MonitorsConnected";
            this.numericBox_MonitorsConnected.Size = new System.Drawing.Size(39, 20);
            this.numericBox_MonitorsConnected.TabIndex = 2;
            // 
            // comboBox_InputDevices
            // 
            this.comboBox_InputDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_InputDevices.FormattingEnabled = true;
            this.comboBox_InputDevices.Location = new System.Drawing.Point(135, 52);
            this.comboBox_InputDevices.Name = "comboBox_InputDevices";
            this.comboBox_InputDevices.Size = new System.Drawing.Size(232, 21);
            this.comboBox_InputDevices.TabIndex = 4;
            // 
            // textBox_MonitorsConnected
            // 
            this.textBox_MonitorsConnected.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_MonitorsConnected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_MonitorsConnected.Location = new System.Drawing.Point(135, 24);
            this.textBox_MonitorsConnected.Name = "textBox_MonitorsConnected";
            this.textBox_MonitorsConnected.Size = new System.Drawing.Size(187, 20);
            this.textBox_MonitorsConnected.TabIndex = 1;
            this.textBox_MonitorsConnected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_DockingStation
            // 
            this.checkBox_DockingStation.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox_DockingStation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkBox_DockingStation.Location = new System.Drawing.Point(135, 83);
            this.checkBox_DockingStation.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_DockingStation.Name = "checkBox_DockingStation";
            this.checkBox_DockingStation.Size = new System.Drawing.Size(13, 13);
            this.checkBox_DockingStation.TabIndex = 6;
            this.checkBox_DockingStation.UseVisualStyleBackColor = false;
            // 
            // label_MonitorsConnected
            // 
            this.label_MonitorsConnected.AutoSize = true;
            this.label_MonitorsConnected.ForeColor = System.Drawing.Color.White;
            this.label_MonitorsConnected.Location = new System.Drawing.Point(19, 26);
            this.label_MonitorsConnected.Name = "label_MonitorsConnected";
            this.label_MonitorsConnected.Size = new System.Drawing.Size(104, 13);
            this.label_MonitorsConnected.TabIndex = 0;
            this.label_MonitorsConnected.Text = "Monitors connected:";
            // 
            // label_InputDevices
            // 
            this.label_InputDevices.AutoSize = true;
            this.label_InputDevices.ForeColor = System.Drawing.Color.White;
            this.label_InputDevices.Location = new System.Drawing.Point(19, 55);
            this.label_InputDevices.Name = "label_InputDevices";
            this.label_InputDevices.Size = new System.Drawing.Size(74, 13);
            this.label_InputDevices.TabIndex = 3;
            this.label_InputDevices.Text = "Input devices:";
            // 
            // label_DockingStation
            // 
            this.label_DockingStation.AutoSize = true;
            this.label_DockingStation.ForeColor = System.Drawing.Color.White;
            this.label_DockingStation.Location = new System.Drawing.Point(19, 84);
            this.label_DockingStation.Name = "label_DockingStation";
            this.label_DockingStation.Size = new System.Drawing.Size(86, 13);
            this.label_DockingStation.TabIndex = 5;
            this.label_DockingStation.Text = "Docking Station:";
            // 
            // btn_ReadSpecs
            // 
            this.btn_ReadSpecs.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_ReadSpecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReadSpecs.ForeColor = System.Drawing.Color.White;
            this.btn_ReadSpecs.Location = new System.Drawing.Point(581, 227);
            this.btn_ReadSpecs.Name = "btn_ReadSpecs";
            this.btn_ReadSpecs.Size = new System.Drawing.Size(168, 50);
            this.btn_ReadSpecs.TabIndex = 8;
            this.btn_ReadSpecs.Text = "Refresh Specs";
            this.btn_ReadSpecs.UseVisualStyleBackColor = false;
            this.btn_ReadSpecs.Click += new System.EventHandler(this.btn_ReadSpecs_Click);
            // 
            // btn_SaveToDB
            // 
            this.btn_SaveToDB.BackColor = System.Drawing.Color.IndianRed;
            this.btn_SaveToDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveToDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveToDB.ForeColor = System.Drawing.Color.White;
            this.btn_SaveToDB.Location = new System.Drawing.Point(581, 431);
            this.btn_SaveToDB.Name = "btn_SaveToDB";
            this.btn_SaveToDB.Size = new System.Drawing.Size(168, 50);
            this.btn_SaveToDB.TabIndex = 3;
            this.btn_SaveToDB.Text = "Save to DB";
            this.btn_SaveToDB.UseVisualStyleBackColor = false;
            this.btn_SaveToDB.Click += new System.EventHandler(this.btn_SaveToDB_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(944, 541);
            this.Controls.Add(this.btn_SaveToDB);
            this.Controls.Add(this.btn_ReadSpecs);
            this.Controls.Add(this.groupBox_Peripherals);
            this.Controls.Add(this.groupBox_PCspecs);
            this.Controls.Add(this.groupBox_User);
            this.Controls.Add(this.groupBox_PC);
            this.Controls.Add(this.labelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Systems Management Tools: Device Identifier";
            this.groupBox_PC.ResumeLayout(false);
            this.groupBox_PC.PerformLayout();
            this.groupBox_User.ResumeLayout(false);
            this.groupBox_User.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_locationPos)).EndInit();
            this.groupBox_PCspecs.ResumeLayout(false);
            this.groupBox_PCspecs.PerformLayout();
            this.groupBox_Peripherals.ResumeLayout(false);
            this.groupBox_Peripherals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox_MonitorsConnected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Location;
        private System.Windows.Forms.GroupBox groupBox_PC;
        private System.Windows.Forms.GroupBox groupBox_User;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.Label label_OSversion;
        private System.Windows.Forms.Label label_ComputerName;
        private System.Windows.Forms.Label label_SerialNumber;
        private System.Windows.Forms.Label label_Model;
        private System.Windows.Forms.Label label_Manufacturer;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.GroupBox groupBox_PCspecs;
        private System.Windows.Forms.Label label_HDDtype;
        private System.Windows.Forms.Label label_HDDcapacity;
        private System.Windows.Forms.Label label_RAMmoduleDetails;
        private System.Windows.Forms.Label label_RAMcapabilities;
        private System.Windows.Forms.Label label_RAMinstalled;
        private System.Windows.Forms.Label label_CPU;
        private System.Windows.Forms.GroupBox groupBox_Peripherals;
        private System.Windows.Forms.Label label_MonitorsConnected;
        private System.Windows.Forms.Label label_InputDevices;
        private System.Windows.Forms.Label label_DockingStation;
        private System.Windows.Forms.Button btn_ReadSpecs;
        private System.Windows.Forms.Button btn_SaveToDB;
        private System.Windows.Forms.TextBox textBox_ComputerName;
        private System.Windows.Forms.TextBox textBox_SerialNumber;
        private System.Windows.Forms.TextBox textBox_Model;
        private System.Windows.Forms.TextBox textBox_Manufacturer;
        private System.Windows.Forms.TextBox textBox_Type;
        private System.Windows.Forms.TextBox textBox_OSversion;
        private System.Windows.Forms.CheckBox checkBox_DockingStation;
        private System.Windows.Forms.TextBox textBox_HDDtype;
        private System.Windows.Forms.TextBox textBox_HDDcapacity;
        private System.Windows.Forms.TextBox textBox_RAMmoduleDetails;
        private System.Windows.Forms.TextBox textBox_RAMcapabilities;
        private System.Windows.Forms.TextBox textBox_RAMinstalled;
        private System.Windows.Forms.TextBox textBox_CPU;
        private System.Windows.Forms.TextBox box_locationZone;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.TextBox textBox_MonitorsConnected;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.ComboBox comboBox_InputDevices;
        private System.Windows.Forms.NumericUpDown numericBox_MonitorsConnected;
        private System.Windows.Forms.Label lblSide_Match;
        private System.Windows.Forms.Label lblBot_Match;
        private System.Windows.Forms.Label lblTop_Match;
        private System.Windows.Forms.NumericUpDown box_locationPos;
        private System.Windows.Forms.CheckBox checkBox_TPM_BitLocker;
        private System.Windows.Forms.Label label_TPM_BitLocker;
    }
}