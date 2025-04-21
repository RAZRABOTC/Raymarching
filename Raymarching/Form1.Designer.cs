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
            ResultText = new Label();
            PropertyText = new RichTextBox();
            SuspendLayout();
            // 
            // ResultText
            // 
            ResultText.AutoSize = true;
            ResultText.ForeColor = SystemColors.ControlLight;
            ResultText.Location = new Point(615, 9);
            ResultText.Name = "ResultText";
            ResultText.Size = new Size(42, 15);
            ResultText.TabIndex = 0;
            ResultText.Text = "Result";
            // 
            // PropertyText
            // 
            PropertyText.BackColor = Color.Black;
            PropertyText.BorderStyle = BorderStyle.FixedSingle;
            PropertyText.Cursor = Cursors.IBeam;
            PropertyText.ForeColor = Color.FromArgb(255, 221, 0);
            PropertyText.Location = new Point(623, 482);
            PropertyText.Name = "PropertyText";
            PropertyText.ReadOnly = true;
            PropertyText.Size = new Size(447, 98);
            PropertyText.TabIndex = 1;
            PropertyText.Text = "Properties";
            // 
            // RayMarchingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1082, 592);
            Controls.Add(PropertyText);
            Controls.Add(ResultText);
            Cursor = Cursors.Cross;
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "RayMarchingForm";
            Text = "Raymarching";
            Paint += RayMarchingForm_Paint;
            MouseMove += RayMarchingForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label ResultText;
        private RichTextBox PropertyText;
    }
}
