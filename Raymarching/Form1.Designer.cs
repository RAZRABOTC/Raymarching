namespace Raymarching
{
    partial class RayMarchingForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PropertyText = new Label();
            SuspendLayout();
            // 
            // PropertyText
            // 
            PropertyText.AutoSize = true;
            PropertyText.ForeColor = SystemColors.ControlLight;
            PropertyText.Location = new Point(12, 426);
            PropertyText.Name = "PropertyText";
            PropertyText.Size = new Size(96, 15);
            PropertyText.TabIndex = 0;
            PropertyText.Text = "CameraDirecion";
            // 
            // RayMarchingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(PropertyText);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "RayMarchingForm";
            Text = "Raymarching";
            Paint += RayMarchingForm_Paint;
            MouseMove += RayMarchingForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label PropertyText;
    }
}
