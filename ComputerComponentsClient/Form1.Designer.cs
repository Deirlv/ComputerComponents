namespace ComputerComponentsClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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
            gridComponents = new DataGridView();
            textBoxComponent = new TextBox();
            buttonFind = new Button();
            ((System.ComponentModel.ISupportInitialize)gridComponents).BeginInit();
            SuspendLayout();
            // 
            // gridComponents
            // 
            gridComponents.AllowUserToAddRows = false;
            gridComponents.AllowUserToDeleteRows = false;
            gridComponents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridComponents.Location = new Point(12, 12);
            gridComponents.Name = "gridComponents";
            gridComponents.ReadOnly = true;
            gridComponents.RowTemplate.Height = 25;
            gridComponents.Size = new Size(776, 373);
            gridComponents.TabIndex = 0;
            // 
            // textBoxComponent
            // 
            textBoxComponent.Location = new Point(250, 407);
            textBoxComponent.Name = "textBoxComponent";
            textBoxComponent.PlaceholderText = "Component";
            textBoxComponent.Size = new Size(128, 23);
            textBoxComponent.TabIndex = 1;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(395, 407);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(128, 23);
            buttonFind.TabIndex = 3;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFind);
            Controls.Add(textBoxComponent);
            Controls.Add(gridComponents);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gridComponents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridComponents;
        private TextBox textBoxComponent;
        private Button buttonFind;
    }
}
