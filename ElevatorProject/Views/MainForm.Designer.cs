using System.Drawing;
using System.Windows.Forms;

namespace ElevatorProject
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnCloseDoors = new System.Windows.Forms.Button();
            this.btnOpenDoors = new System.Windows.Forms.Button();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnFloor1 = new System.Windows.Forms.Button();
            this.btnFloor0 = new System.Windows.Forms.Button();
            this.lblFloor1 = new System.Windows.Forms.Label();
            this.btnCall1 = new System.Windows.Forms.Button();
            this.lblFloor0 = new System.Windows.Forms.Label();
            this.btnCall0 = new System.Windows.Forms.Button();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlElevator = new System.Windows.Forms.Panel();
            this.pnlFloor0Doors = new System.Windows.Forms.Panel();
            this.floor0DoorLeft = new System.Windows.Forms.Panel();
            this.floor0DoorRight = new System.Windows.Forms.Panel();
            this.pnlFloor1Doors = new System.Windows.Forms.Panel();
            this.floor1DoorLeft = new System.Windows.Forms.Panel();
            this.floor1DoorRight = new System.Windows.Forms.Panel();
            this.pnlShaft = new System.Windows.Forms.Panel();
            this.grpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlFloor0Doors.SuspendLayout();
            this.pnlFloor1Doors.SuspendLayout();
            this.pnlShaft.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnEmergency);
            this.grpControls.Controls.Add(this.btnShowLog);
            this.grpControls.Controls.Add(this.btnCloseDoors);
            this.grpControls.Controls.Add(this.btnOpenDoors);
            this.grpControls.Controls.Add(this.lblDisplay);
            this.grpControls.Controls.Add(this.btnFloor1);
            this.grpControls.Controls.Add(this.btnFloor0);
            this.grpControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpControls.ForeColor = System.Drawing.Color.White;
            this.grpControls.Location = new System.Drawing.Point(469, 143);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(214, 427);
            this.grpControls.TabIndex = 1;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "CONTROL PANEL";
            this.grpControls.Enter += new System.EventHandler(this.grpControls_Enter);
            // 
            // btnEmergency
            // 
            this.btnEmergency.BackColor = System.Drawing.Color.Red;
            this.btnEmergency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmergency.ForeColor = System.Drawing.Color.White;
            this.btnEmergency.Location = new System.Drawing.Point(21, 274);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(173, 55);
            this.btnEmergency.TabIndex = 3;
            this.btnEmergency.Text = " EMERGENCY STOP";
            this.btnEmergency.UseVisualStyleBackColor = false;
            this.btnEmergency.Click += new System.EventHandler(this.btnEmergency_Click);
            // 
            // btnShowLog
            // 
            this.btnShowLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowLog.ForeColor = System.Drawing.Color.White;
            this.btnShowLog.Location = new System.Drawing.Point(48, 358);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(128, 53);
            this.btnShowLog.TabIndex = 7;
            this.btnShowLog.Text = " SHOW LOGS";
            this.btnShowLog.UseVisualStyleBackColor = false;
            // 
            // btnCloseDoors
            // 
            this.btnCloseDoors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCloseDoors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseDoors.ForeColor = System.Drawing.Color.White;
            this.btnCloseDoors.Location = new System.Drawing.Point(48, 215);
            this.btnCloseDoors.Name = "btnCloseDoors";
            this.btnCloseDoors.Size = new System.Drawing.Size(120, 40);
            this.btnCloseDoors.TabIndex = 5;
            this.btnCloseDoors.Text = "CLOSE DOORS";
            this.btnCloseDoors.UseVisualStyleBackColor = false;
            // 
            // btnOpenDoors
            // 
            this.btnOpenDoors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOpenDoors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenDoors.ForeColor = System.Drawing.Color.White;
            this.btnOpenDoors.Location = new System.Drawing.Point(48, 168);
            this.btnOpenDoors.Name = "btnOpenDoors";
            this.btnOpenDoors.Size = new System.Drawing.Size(120, 41);
            this.btnOpenDoors.TabIndex = 6;
            this.btnOpenDoors.Text = "OPEN ";
            this.btnOpenDoors.UseVisualStyleBackColor = false;
            this.btnOpenDoors.Click += new System.EventHandler(this.btnOpenDoors_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.Black;
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.ForeColor = System.Drawing.Color.Lime;
            this.lblDisplay.Location = new System.Drawing.Point(42, 32);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(126, 34);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "FLOOR 0";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDisplay.Click += new System.EventHandler(this.lblDisplay_Click);
            // 
            // btnFloor1
            // 
            this.btnFloor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFloor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnFloor1.ForeColor = System.Drawing.Color.White;
            this.btnFloor1.Location = new System.Drawing.Point(48, 101);
            this.btnFloor1.Name = "btnFloor1";
            this.btnFloor1.Size = new System.Drawing.Size(52, 50);
            this.btnFloor1.TabIndex = 1;
            this.btnFloor1.Text = "1";
            this.btnFloor1.UseVisualStyleBackColor = false;
            this.btnFloor1.Click += new System.EventHandler(this.btnFloor1_Click);
            // 
            // btnFloor0
            // 
            this.btnFloor0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFloor0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloor0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnFloor0.ForeColor = System.Drawing.Color.White;
            this.btnFloor0.Location = new System.Drawing.Point(117, 101);
            this.btnFloor0.Name = "btnFloor0";
            this.btnFloor0.Size = new System.Drawing.Size(51, 50);
            this.btnFloor0.TabIndex = 2;
            this.btnFloor0.Text = "0";
            this.btnFloor0.UseVisualStyleBackColor = false;
            this.btnFloor0.Click += new System.EventHandler(this.btnFloor0_Click);
            // 
            // lblFloor1
            // 
            this.lblFloor1.AutoSize = true;
            this.lblFloor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloor1.Location = new System.Drawing.Point(502, 26);
            this.lblFloor1.Name = "lblFloor1";
            this.lblFloor1.Size = new System.Drawing.Size(103, 25);
            this.lblFloor1.TabIndex = 2;
            this.lblFloor1.Text = "FLOOR 1";
            // 
            // btnCall1
            // 
            this.btnCall1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCall1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCall1.ForeColor = System.Drawing.Color.White;
            this.btnCall1.Location = new System.Drawing.Point(493, 54);
            this.btnCall1.Name = "btnCall1";
            this.btnCall1.Size = new System.Drawing.Size(98, 45);
            this.btnCall1.TabIndex = 3;
            this.btnCall1.Text = "🔼 CALL";
            this.btnCall1.UseVisualStyleBackColor = false;
            // 
            // lblFloor0
            // 
            this.lblFloor0.AutoSize = true;
            this.lblFloor0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloor0.Location = new System.Drawing.Point(444, 629);
            this.lblFloor0.Name = "lblFloor0";
            this.lblFloor0.Size = new System.Drawing.Size(103, 25);
            this.lblFloor0.TabIndex = 4;
            this.lblFloor0.Text = "FLOOR 0";
            // 
            // btnCall0
            // 
            this.btnCall0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCall0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCall0.ForeColor = System.Drawing.Color.White;
            this.btnCall0.Location = new System.Drawing.Point(449, 657);
            this.btnCall0.Name = "btnCall0";
            this.btnCall0.Size = new System.Drawing.Size(98, 45);
            this.btnCall0.TabIndex = 5;
            this.btnCall0.Text = "🔽 CALL ";
            this.btnCall0.UseVisualStyleBackColor = false;
            // 
            // dgvLogs
            // 
            this.dgvLogs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(704, 12);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.Size = new System.Drawing.Size(384, 709);
            this.dgvLogs.TabIndex = 6;
            this.dgvLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogs_CellContentClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            // 
            // pnlElevator
            // 
            this.pnlElevator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlElevator.Location = new System.Drawing.Point(50, 380);
            this.pnlElevator.Name = "pnlElevator";
            this.pnlElevator.Size = new System.Drawing.Size(200, 280);
            this.pnlElevator.TabIndex = 1;
            // 
            // pnlFloor0Doors
            // 
            this.pnlFloor0Doors.BackColor = System.Drawing.Color.Transparent;
            this.pnlFloor0Doors.Controls.Add(this.floor0DoorLeft);
            this.pnlFloor0Doors.Controls.Add(this.floor0DoorRight);
            this.pnlFloor0Doors.Location = new System.Drawing.Point(50, 380);
            this.pnlFloor0Doors.Name = "pnlFloor0Doors";
            this.pnlFloor0Doors.Size = new System.Drawing.Size(200, 280);
            this.pnlFloor0Doors.TabIndex = 2;
            // 
            // floor0DoorLeft
            // 
            this.floor0DoorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor0DoorLeft.Location = new System.Drawing.Point(0, 0);
            this.floor0DoorLeft.Name = "floor0DoorLeft";
            this.floor0DoorLeft.Size = new System.Drawing.Size(100, 280);
            this.floor0DoorLeft.TabIndex = 0;
            // 
            // floor0DoorRight
            // 
            this.floor0DoorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor0DoorRight.Location = new System.Drawing.Point(100, 0);
            this.floor0DoorRight.Name = "floor0DoorRight";
            this.floor0DoorRight.Size = new System.Drawing.Size(100, 280);
            this.floor0DoorRight.TabIndex = 1;
            this.floor0DoorRight.Paint += new System.Windows.Forms.PaintEventHandler(this.floor0DoorRight_Paint);
            // 
            // pnlFloor1Doors
            // 
            this.pnlFloor1Doors.BackColor = System.Drawing.Color.Transparent;
            this.pnlFloor1Doors.Controls.Add(this.floor1DoorLeft);
            this.pnlFloor1Doors.Controls.Add(this.floor1DoorRight);
            this.pnlFloor1Doors.Location = new System.Drawing.Point(50, 40);
            this.pnlFloor1Doors.Name = "pnlFloor1Doors";
            this.pnlFloor1Doors.Size = new System.Drawing.Size(200, 280);
            this.pnlFloor1Doors.TabIndex = 3;
            // 
            // floor1DoorLeft
            // 
            this.floor1DoorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor1DoorLeft.Location = new System.Drawing.Point(0, 0);
            this.floor1DoorLeft.Name = "floor1DoorLeft";
            this.floor1DoorLeft.Size = new System.Drawing.Size(100, 280);
            this.floor1DoorLeft.TabIndex = 0;
            // 
            // floor1DoorRight
            // 
            this.floor1DoorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor1DoorRight.Location = new System.Drawing.Point(100, 0);
            this.floor1DoorRight.Name = "floor1DoorRight";
            this.floor1DoorRight.Size = new System.Drawing.Size(100, 280);
            this.floor1DoorRight.TabIndex = 1;
            // 
            // pnlShaft
            // 
            this.pnlShaft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlShaft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlShaft.Controls.Add(this.pnlFloor1Doors);
            this.pnlShaft.Controls.Add(this.pnlFloor0Doors);
            this.pnlShaft.Controls.Add(this.pnlElevator);
            this.pnlShaft.ForeColor = System.Drawing.Color.Tomato;
            this.pnlShaft.Location = new System.Drawing.Point(77, 12);
            this.pnlShaft.Name = "pnlShaft";
            this.pnlShaft.Size = new System.Drawing.Size(341, 700);
            this.pnlShaft.TabIndex = 0;
            this.pnlShaft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlShaft_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.btnCall0);
            this.Controls.Add(this.lblFloor0);
            this.Controls.Add(this.btnCall1);
            this.Controls.Add(this.lblFloor1);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.pnlShaft);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.Text = "ELEVATOR CONTROL SYSTEM";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlFloor0Doors.ResumeLayout(false);
            this.pnlFloor1Doors.ResumeLayout(false);
            this.pnlShaft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnFloor1;
        private System.Windows.Forms.Button btnFloor0;
        private System.Windows.Forms.Label lblFloor1;
        private System.Windows.Forms.Button btnCall1;
        private System.Windows.Forms.Label lblFloor0;
        private System.Windows.Forms.Button btnCall0;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Button btnOpenDoors;
        private System.Windows.Forms.Button btnCloseDoors;
        private Panel pnlElevator;
        private Panel pnlFloor0Doors;
        private Panel floor0DoorLeft;
        private Panel floor0DoorRight;
        private Panel pnlFloor1Doors;
        private Panel floor1DoorLeft;
        private Panel floor1DoorRight;
        private Panel pnlShaft;
    }
}