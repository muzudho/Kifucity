namespace Grayscale.A500_Kifucity
{
    partial class Form1
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
            this.ucMain1 = new Grayscale.A500_Kifucity.UcMain();
            this.SuspendLayout();
            // 
            // ucMain1
            // 
            this.ucMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMain1.Images = null;
            this.ucMain1.IsButtonEffected = false;
            this.ucMain1.Location = new System.Drawing.Point(0, 0);
            this.ucMain1.MapchipProperties = null;
            this.ucMain1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.ucMain1.Name = "ucMain1";
            this.ucMain1.SaveFileVersion = 3;
            this.ucMain1.Size = new System.Drawing.Size(600, 400);
            this.ucMain1.TabIndex = 0;
            this.ucMain1.TableLeft = 16;
            this.ucMain1.TableTop = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.ucMain1);
            this.Name = "Form1";
            this.Text = "ここは使わない";
            this.ResumeLayout(false);

        }

        #endregion

        private UcMain ucMain1;
    }
}

