using System.Drawing;
using System.Windows.Forms;

namespace ElevatorProject
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox grpControls;
        private Label lblDisplay;
        private Button btnFloor1;
        private Button btnFloor0;
        private Label lblFloor1;
        private Button btnCall1;
        private Label lblFloor0;
        private Button btnCall0;
        private DataGridView dgvLogs;
        private Button btnShowLog;
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenDoors;
        private Button btnCloseDoors;
        private Panel pnlElevator;
        private Panel pnlFloor0Doors;
        private Panel floor0DoorLeft;
        private Panel floor0DoorRight;
        private Panel pnlFloor1Doors;
        private Panel floor1DoorLeft;
        private Panel floor1DoorRight;
        private Panel pnlShaft;
        private Label lblTitle;
        private Button btnClearLogs;

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
            this.components = new System.ComponentModel.Container();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnCloseDoors = new System.Windows.Forms.Button();
            this.btnOpenDoors = new System.Windows.Forms.Button();
            this.btnFloor0 = new System.Windows.Forms.Button();
            this.btnFloor1 = new System.Windows.Forms.Button();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblFloor1 = new System.Windows.Forms.Label();
            this.btnCall1 = new System.Windows.Forms.Button();
            this.lblFloor0 = new System.Windows.Forms.Label();
            this.btnCall0 = new System.Windows.Forms.Button();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlShaft = new System.Windows.Forms.Panel();
            this.pnlFloor1Doors = new System.Windows.Forms.Panel();
            this.floor1DoorLeft = new System.Windows.Forms.Panel();
            this.floor1DoorRight = new System.Windows.Forms.Panel();
            this.pnlFloor0Doors = new System.Windows.Forms.Panel();
            this.floor0DoorLeft = new System.Windows.Forms.Panel();
            this.floor0DoorRight = new System.Windows.Forms.Panel();
            this.pnlElevator = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            // grpControls
            this.grpControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpControls.Controls.Add(this.btnClearLogs);
            this.grpControls.Controls.Add(this.btnShowLog);
            this.grpControls.Controls.Add(this.btnCloseDoors);
            this.grpControls.Controls.Add(this.btnOpenDoors);
            this.grpControls.Controls.Add(this.btnFloor0);
            this.grpControls.Controls.Add(this.btnFloor1);
            this.grpControls.Controls.Add(this.lblDisplay);
            this.grpControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpControls.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpControls.ForeColor = System.Drawing.Color.White;
            this.grpControls.Location = new System.Drawing.Point(450, 150);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(240, 320);
            this.grpControls.TabIndex = 1;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "CONTROL PANEL";

            // btnClearLogs
            this.btnClearLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnClearLogs.FlatAppearance.BorderSize = 0;
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearLogs.ForeColor = System.Drawing.Color.White;
            this.btnClearLogs.Location = new System.Drawing.Point(130, 270);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(100, 35);
            this.btnClearLogs.TabIndex = 8;
            this.btnClearLogs.Text = "CLEAR LOGS";
            this.btnClearLogs.UseVisualStyleBackColor = false;

            // btnShowLog
            this.btnShowLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnShowLog.FlatAppearance.BorderSize = 0;
            this.btnShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowLog.ForeColor = System.Drawing.Color.White;
            this.btnShowLog.Location = new System.Drawing.Point(20, 270);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(100, 35);
            this.btnShowLog.TabIndex = 7;
            this.btnShowLog.Text = "SHOW LOGS";
            this.btnShowLog.UseVisualStyleBackColor = false;

            // btnCloseDoors
            this.btnCloseDoors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCloseDoors.FlatAppearance.BorderSize = 0;
            this.btnCloseDoors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDoors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseDoors.ForeColor = System.Drawing.Color.White;
            this.btnCloseDoors.Location = new System.Drawing.Point(130, 220);
            this.btnCloseDoors.Name = "btnCloseDoors";
            this.btnCloseDoors.Size = new System.Drawing.Size(100, 35);
            this.btnCloseDoors.TabIndex = 5;
            this.btnCloseDoors.Text = "CLOSE";
            this.btnCloseDoors.UseVisualStyleBackColor = false;

            // btnOpenDoors
            this.btnOpenDoors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOpenDoors.FlatAppearance.BorderSize = 0;
            this.btnOpenDoors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDoors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenDoors.ForeColor = System.Drawing.Color.White;
            this.btnOpenDoors.Location = new System.Drawing.Point(20, 220);
            this.btnOpenDoors.Name = "btnOpenDoors";
            this.btnOpenDoors.Size = new System.Drawing.Size(100, 35);
            this.btnOpenDoors.TabIndex = 6;
            this.btnOpenDoors.Text = "OPEN";
            this.btnOpenDoors.UseVisualStyleBackColor = false;

            // btnFloor0
            this.btnFloor0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFloor0.FlatAppearance.BorderSize = 0;
            this.btnFloor0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloor0.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnFloor0.ForeColor = System.Drawing.Color.White;
            this.btnFloor0.Location = new System.Drawing.Point(140, 140);
            this.btnFloor0.Name = "btnFloor0";
            this.btnFloor0.Size = new System.Drawing.Size(60, 60);
            this.btnFloor0.TabIndex = 2;
            this.btnFloor0.Text = "0";
            this.btnFloor0.UseVisualStyleBackColor = false;

            // btnFloor1
            this.btnFloor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFloor1.FlatAppearance.BorderSize = 0;
            this.btnFloor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloor1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnFloor1.ForeColor = System.Drawing.Color.White;
            this.btnFloor1.Location = new System.Drawing.Point(55, 140);
            this.btnFloor1.Name = "btnFloor1";
            this.btnFloor1.Size = new System.Drawing.Size(60, 60);
            this.btnFloor1.TabIndex = 1;
            this.btnFloor1.Text = "1";
            this.btnFloor1.UseVisualStyleBackColor = false;

            // lblDisplay
            this.lblDisplay.BackColor = System.Drawing.Color.Black;
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.ForeColor = System.Drawing.Color.Lime;
            this.lblDisplay.Location = new System.Drawing.Point(30, 40);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(180, 50);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "FLOOR 0";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblFloor1
            this.lblFloor1.AutoSize = true;
            this.lblFloor1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloor1.ForeColor = System.Drawing.Color.White;
            this.lblFloor1.Location = new System.Drawing.Point(480, 90);
            this.lblFloor1.Name = "lblFloor1";
            this.lblFloor1.Size = new System.Drawing.Size(90, 28);
            this.lblFloor1.TabIndex = 2;
            this.lblFloor1.Text = "FLOOR 1";

            // btnCall1
            this.btnCall1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCall1.FlatAppearance.BorderSize = 0;
            this.btnCall1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCall1.ForeColor = System.Drawing.Color.White;
            this.btnCall1.Location = new System.Drawing.Point(480, 120);
            this.btnCall1.Name = "btnCall1";
            this.btnCall1.Size = new System.Drawing.Size(100, 40);
            this.btnCall1.TabIndex = 3;
            this.btnCall1.Text = "🔼 CALL";
            this.btnCall1.UseVisualStyleBackColor = false;

            // lblFloor0
            this.lblFloor0.AutoSize = true;
            this.lblFloor0.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFloor0.ForeColor = System.Drawing.Color.White;
            this.lblFloor0.Location = new System.Drawing.Point(430, 520);
            this.lblFloor0.Name = "lblFloor0";
            this.lblFloor0.Size = new System.Drawing.Size(90, 28);
            this.lblFloor0.TabIndex = 4;
            this.lblFloor0.Text = "FLOOR 0";

            // btnCall0
            this.btnCall0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCall0.FlatAppearance.BorderSize = 0;
            this.btnCall0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall0.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCall0.ForeColor = System.Drawing.Color.White;
            this.btnCall0.Location = new System.Drawing.Point(430, 550);
            this.btnCall0.Name = "btnCall0";
            this.btnCall0.Size = new System.Drawing.Size(100, 40);
            this.btnCall0.TabIndex = 5;
            this.btnCall0.Text = "🔽 CALL";
            this.btnCall0.UseVisualStyleBackColor = false;

            // dgvLogs
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(710, 80);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.Size = new System.Drawing.Size(360, 640);
            this.dgvLogs.TabIndex = 6;

            // timer1
            this.timer1.Interval = 50;

            // pnlShaft
            this.pnlShaft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlShaft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlShaft.Controls.Add(this.pnlFloor1Doors);
            this.pnlShaft.Controls.Add(this.pnlFloor0Doors);
            this.pnlShaft.Controls.Add(this.pnlElevator);
            this.pnlShaft.Location = new System.Drawing.Point(80, 80);
            this.pnlShaft.Name = "pnlShaft";
            this.pnlShaft.Size = new System.Drawing.Size(320, 700);
            this.pnlShaft.TabIndex = 0;

            // pnlFloor1Doors
            this.pnlFloor1Doors.BackColor = System.Drawing.Color.Transparent;
            this.pnlFloor1Doors.Controls.Add(this.floor1DoorLeft);
            this.pnlFloor1Doors.Controls.Add(this.floor1DoorRight);
            this.pnlFloor1Doors.Location = new System.Drawing.Point(40, 40);
            this.pnlFloor1Doors.Name = "pnlFloor1Doors";
            this.pnlFloor1Doors.Size = new System.Drawing.Size(240, 280);
            this.pnlFloor1Doors.TabIndex = 3;

            // floor1DoorLeft
            this.floor1DoorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor1DoorLeft.Location = new System.Drawing.Point(0, 0);
            this.floor1DoorLeft.Name = "floor1DoorLeft";
            this.floor1DoorLeft.Size = new System.Drawing.Size(120, 280);
            this.floor1DoorLeft.TabIndex = 0;

            // floor1DoorRight
            this.floor1DoorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor1DoorRight.Location = new System.Drawing.Point(120, 0);
            this.floor1DoorRight.Name = "floor1DoorRight";
            this.floor1DoorRight.Size = new System.Drawing.Size(120, 280);
            this.floor1DoorRight.TabIndex = 1;

            // pnlFloor0Doors
            this.pnlFloor0Doors.BackColor = System.Drawing.Color.Transparent;
            this.pnlFloor0Doors.Controls.Add(this.floor0DoorLeft);
            this.pnlFloor0Doors.Controls.Add(this.floor0DoorRight);
            this.pnlFloor0Doors.Location = new System.Drawing.Point(40, 380);
            this.pnlFloor0Doors.Name = "pnlFloor0Doors";
            this.pnlFloor0Doors.Size = new System.Drawing.Size(240, 280);
            this.pnlFloor0Doors.TabIndex = 2;

            // floor0DoorLeft
            this.floor0DoorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor0DoorLeft.Location = new System.Drawing.Point(0, 0);
            this.floor0DoorLeft.Name = "floor0DoorLeft";
            this.floor0DoorLeft.Size = new System.Drawing.Size(120, 280);
            this.floor0DoorLeft.TabIndex = 0;

            // floor0DoorRight
            this.floor0DoorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.floor0DoorRight.Location = new System.Drawing.Point(120, 0);
            this.floor0DoorRight.Name = "floor0DoorRight";
            this.floor0DoorRight.Size = new System.Drawing.Size(120, 280);
            this.floor0DoorRight.TabIndex = 1;

            // pnlElevator
            this.pnlElevator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlElevator.Location = new System.Drawing.Point(40, 380);
            this.pnlElevator.Name = "pnlElevator";
            this.pnlElevator.Size = new System.Drawing.Size(240, 280);
            this.pnlElevator.TabIndex = 1;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(74, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(386, 41);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "ELEVATOR CONTROL SYSTEM";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.btnCall0);
            this.Controls.Add(this.lblFloor0);
            this.Controls.Add(this.btnCall1);
            this.Controls.Add(this.lblFloor1);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.pnlShaft);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elevator Control System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlShaft.ResumeLayout(false);
            this.pnlFloor1Doors.ResumeLayout(false);
            this.pnlFloor0Doors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}