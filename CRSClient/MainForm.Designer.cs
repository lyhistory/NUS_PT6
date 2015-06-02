﻿namespace CRSClient
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
            this.btnRegistrateCourse = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnCourseConfirm = new System.Windows.Forms.Button();
            this.btnCourseComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegistrateCourse
            // 
            this.btnRegistrateCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrateCourse.Location = new System.Drawing.Point(36, 12);
            this.btnRegistrateCourse.Name = "btnRegistrateCourse";
            this.btnRegistrateCourse.Size = new System.Drawing.Size(349, 62);
            this.btnRegistrateCourse.TabIndex = 0;
            this.btnRegistrateCourse.Text = "Course Registration";
            this.btnRegistrateCourse.UseVisualStyleBackColor = true;
            this.btnRegistrateCourse.Click += new System.EventHandler(this.btnRegistrateCourse_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnAttendance.Location = new System.Drawing.Point(36, 113);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(349, 62);
            this.btnAttendance.TabIndex = 1;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnCourseConfirm
            // 
            this.btnCourseConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCourseConfirm.Location = new System.Drawing.Point(36, 214);
            this.btnCourseConfirm.Name = "btnCourseConfirm";
            this.btnCourseConfirm.Size = new System.Drawing.Size(349, 62);
            this.btnCourseConfirm.TabIndex = 2;
            this.btnCourseConfirm.Text = "Course Confirmation";
            this.btnCourseConfirm.UseVisualStyleBackColor = true;
            this.btnCourseConfirm.Click += new System.EventHandler(this.btnCourseConfirm_Click);
            // 
            // btnCourseComplete
            // 
            this.btnCourseComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCourseComplete.Location = new System.Drawing.Point(36, 315);
            this.btnCourseComplete.Name = "btnCourseComplete";
            this.btnCourseComplete.Size = new System.Drawing.Size(349, 62);
            this.btnCourseComplete.TabIndex = 3;
            this.btnCourseComplete.Text = "Course Completion";
            this.btnCourseComplete.UseVisualStyleBackColor = true;
            this.btnCourseComplete.Click += new System.EventHandler(this.btnCourseComplete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 390);
            this.Controls.Add(this.btnCourseComplete);
            this.Controls.Add(this.btnCourseConfirm);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.btnRegistrateCourse);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrateCourse;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnCourseConfirm;
        private System.Windows.Forms.Button btnCourseComplete;
    }
}