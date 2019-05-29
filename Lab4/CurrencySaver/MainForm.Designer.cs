namespace CurrencySaver
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._currencyNamesUriLabel = new System.Windows.Forms.Label();
            this._currencyInfosUriLabel = new System.Windows.Forms.Label();
            this._currencyNamesUriBox = new System.Windows.Forms.TextBox();
            this._currencyInfosUriBox = new System.Windows.Forms.TextBox();
            this._avgUpdateTimeDescriptionLabel = new System.Windows.Forms.Label();
            this._avgUpdateTimeLabel = new System.Windows.Forms.Label();
            this._updateTimesGroup = new System.Windows.Forms.GroupBox();
            this._asyncUsingRadioButton = new System.Windows.Forms.RadioButton();
            this._syncUsingRadioButton = new System.Windows.Forms.RadioButton();
            this._saveCurrenciesButton = new System.Windows.Forms.Button();
            this._updateTimesList = new System.Windows.Forms.ListBox();
            this._updateTimesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _currencyNamesUriLabel
            // 
            this._currencyNamesUriLabel.AutoSize = true;
            this._currencyNamesUriLabel.Location = new System.Drawing.Point(21, 26);
            this._currencyNamesUriLabel.Name = "_currencyNamesUriLabel";
            this._currencyNamesUriLabel.Size = new System.Drawing.Size(234, 17);
            this._currencyNamesUriLabel.TabIndex = 0;
            this._currencyNamesUriLabel.Text = "Путь к файлу с названиями валют";
            // 
            // _currencyInfosUriLabel
            // 
            this._currencyInfosUriLabel.AutoSize = true;
            this._currencyInfosUriLabel.Location = new System.Drawing.Point(21, 88);
            this._currencyInfosUriLabel.Name = "_currencyInfosUriLabel";
            this._currencyInfosUriLabel.Size = new System.Drawing.Size(363, 17);
            this._currencyInfosUriLabel.TabIndex = 1;
            this._currencyInfosUriLabel.Text = "Путь к файлу для сохранения информации о валютах";
            // 
            // _currencyNamesUriBox
            // 
            this._currencyNamesUriBox.Location = new System.Drawing.Point(24, 46);
            this._currencyNamesUriBox.Name = "_currencyNamesUriBox";
            this._currencyNamesUriBox.Size = new System.Drawing.Size(196, 22);
            this._currencyNamesUriBox.TabIndex = 2;
            // 
            // _currencyInfosUriBox
            // 
            this._currencyInfosUriBox.Location = new System.Drawing.Point(24, 108);
            this._currencyInfosUriBox.Name = "_currencyInfosUriBox";
            this._currencyInfosUriBox.Size = new System.Drawing.Size(196, 22);
            this._currencyInfosUriBox.TabIndex = 3;
            // 
            // _avgUpdateTimeDescriptionLabel
            // 
            this._avgUpdateTimeDescriptionLabel.AutoSize = true;
            this._avgUpdateTimeDescriptionLabel.Location = new System.Drawing.Point(21, 485);
            this._avgUpdateTimeDescriptionLabel.Name = "_avgUpdateTimeDescriptionLabel";
            this._avgUpdateTimeDescriptionLabel.Size = new System.Drawing.Size(233, 17);
            this._avgUpdateTimeDescriptionLabel.TabIndex = 4;
            this._avgUpdateTimeDescriptionLabel.Text = "Среднее время выполнения в мс: ";
            // 
            // _avgUpdateTimeLabel
            // 
            this._avgUpdateTimeLabel.AutoSize = true;
            this._avgUpdateTimeLabel.Location = new System.Drawing.Point(260, 485);
            this._avgUpdateTimeLabel.Name = "_avgUpdateTimeLabel";
            this._avgUpdateTimeLabel.Size = new System.Drawing.Size(16, 17);
            this._avgUpdateTimeLabel.TabIndex = 5;
            this._avgUpdateTimeLabel.Text = "0";
            // 
            // _updateTimesGroup
            // 
            this._updateTimesGroup.Controls.Add(this._updateTimesList);
            this._updateTimesGroup.Location = new System.Drawing.Point(24, 235);
            this._updateTimesGroup.Name = "_updateTimesGroup";
            this._updateTimesGroup.Size = new System.Drawing.Size(282, 234);
            this._updateTimesGroup.TabIndex = 6;
            this._updateTimesGroup.TabStop = false;
            this._updateTimesGroup.Text = "Время выполнений";
            // 
            // _asyncUsingRadioButton
            // 
            this._asyncUsingRadioButton.AutoSize = true;
            this._asyncUsingRadioButton.Location = new System.Drawing.Point(24, 148);
            this._asyncUsingRadioButton.Name = "_asyncUsingRadioButton";
            this._asyncUsingRadioButton.Size = new System.Drawing.Size(107, 21);
            this._asyncUsingRadioButton.TabIndex = 7;
            this._asyncUsingRadioButton.TabStop = true;
            this._asyncUsingRadioButton.Text = "Асинхронно";
            this._asyncUsingRadioButton.UseVisualStyleBackColor = true;
            this._asyncUsingRadioButton.CheckedChanged += new System.EventHandler(this._asyncUsingRadioButton_CheckedChanged);
            // 
            // _syncUsingRadioButton
            // 
            this._syncUsingRadioButton.AutoSize = true;
            this._syncUsingRadioButton.Location = new System.Drawing.Point(241, 148);
            this._syncUsingRadioButton.Name = "_syncUsingRadioButton";
            this._syncUsingRadioButton.Size = new System.Drawing.Size(100, 21);
            this._syncUsingRadioButton.TabIndex = 8;
            this._syncUsingRadioButton.TabStop = true;
            this._syncUsingRadioButton.Text = "Синхронно";
            this._syncUsingRadioButton.UseVisualStyleBackColor = true;
            this._syncUsingRadioButton.CheckedChanged += new System.EventHandler(this._syncUsingRadioButton_CheckedChanged);
            // 
            // _saveCurrenciesButton
            // 
            this._saveCurrenciesButton.Location = new System.Drawing.Point(24, 190);
            this._saveCurrenciesButton.Name = "_saveCurrenciesButton";
            this._saveCurrenciesButton.Size = new System.Drawing.Size(95, 23);
            this._saveCurrenciesButton.TabIndex = 9;
            this._saveCurrenciesButton.Text = "Сохранить";
            this._saveCurrenciesButton.UseVisualStyleBackColor = true;
            // 
            // _updateTimesList
            // 
            this._updateTimesList.FormattingEnabled = true;
            this._updateTimesList.ItemHeight = 16;
            this._updateTimesList.Location = new System.Drawing.Point(6, 28);
            this._updateTimesList.Name = "_updateTimesList";
            this._updateTimesList.Size = new System.Drawing.Size(270, 196);
            this._updateTimesList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 524);
            this.Controls.Add(this._saveCurrenciesButton);
            this.Controls.Add(this._syncUsingRadioButton);
            this.Controls.Add(this._asyncUsingRadioButton);
            this.Controls.Add(this._updateTimesGroup);
            this.Controls.Add(this._avgUpdateTimeLabel);
            this.Controls.Add(this._avgUpdateTimeDescriptionLabel);
            this.Controls.Add(this._currencyInfosUriBox);
            this.Controls.Add(this._currencyNamesUriBox);
            this.Controls.Add(this._currencyInfosUriLabel);
            this.Controls.Add(this._currencyNamesUriLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this._updateTimesGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _currencyNamesUriLabel;
        private System.Windows.Forms.Label _currencyInfosUriLabel;
        private System.Windows.Forms.TextBox _currencyNamesUriBox;
        private System.Windows.Forms.TextBox _currencyInfosUriBox;
        private System.Windows.Forms.Label _avgUpdateTimeDescriptionLabel;
        private System.Windows.Forms.Label _avgUpdateTimeLabel;
        private System.Windows.Forms.GroupBox _updateTimesGroup;
        private System.Windows.Forms.RadioButton _asyncUsingRadioButton;
        private System.Windows.Forms.RadioButton _syncUsingRadioButton;
        private System.Windows.Forms.Button _saveCurrenciesButton;
        private System.Windows.Forms.ListBox _updateTimesList;
    }
}

