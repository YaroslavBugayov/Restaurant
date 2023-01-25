namespace PL
{
    partial class RestaurantWindow
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.labelResultOrder = new System.Windows.Forms.Label();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDishes = new System.Windows.Forms.ComboBox();
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRemoveOrder = new System.Windows.Forms.Button();
            this.buttonSendOrders = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonPreviousOrders = new System.Windows.Forms.Button();
            this.panelOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(262, 13);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(300, 29);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to our restaurant,";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(277, 42);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(48, 22);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "User";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(713, 13);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(75, 29);
            this.buttonSignIn.TabIndex = 2;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(713, 49);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(75, 29);
            this.buttonSignUp.TabIndex = 3;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Location = new System.Drawing.Point(713, 14);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(75, 28);
            this.buttonSignOut.TabIndex = 4;
            this.buttonSignOut.Text = "Sign Out";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.buttonSignOut_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(139, 81);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(200, 32);
            this.buttonCreateOrder.TabIndex = 5;
            this.buttonCreateOrder.Text = "Create Order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.labelResultOrder);
            this.panelOrder.Controls.Add(this.buttonAddOrder);
            this.panelOrder.Controls.Add(this.label1);
            this.panelOrder.Controls.Add(this.comboBoxDishes);
            this.panelOrder.Location = new System.Drawing.Point(69, 119);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(332, 220);
            this.panelOrder.TabIndex = 6;
            // 
            // labelResultOrder
            // 
            this.labelResultOrder.AutoSize = true;
            this.labelResultOrder.Location = new System.Drawing.Point(14, 64);
            this.labelResultOrder.Name = "labelResultOrder";
            this.labelResultOrder.Size = new System.Drawing.Size(0, 16);
            this.labelResultOrder.TabIndex = 15;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(240, 24);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOrder.TabIndex = 14;
            this.buttonAddOrder.Text = "Add";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select dish";
            // 
            // comboBoxDishes
            // 
            this.comboBoxDishes.FormattingEnabled = true;
            this.comboBoxDishes.Location = new System.Drawing.Point(3, 23);
            this.comboBoxDishes.Name = "comboBoxDishes";
            this.comboBoxDishes.Size = new System.Drawing.Size(228, 24);
            this.comboBoxDishes.TabIndex = 7;
            this.comboBoxDishes.SelectedIndexChanged += new System.EventHandler(this.comboBoxDishes_SelectedIndexChanged);
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.ItemHeight = 16;
            this.listBoxOrders.Location = new System.Drawing.Point(453, 119);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(250, 164);
            this.listBoxOrders.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Your orders";
            // 
            // buttonRemoveOrder
            // 
            this.buttonRemoveOrder.Location = new System.Drawing.Point(539, 289);
            this.buttonRemoveOrder.Name = "buttonRemoveOrder";
            this.buttonRemoveOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveOrder.TabIndex = 9;
            this.buttonRemoveOrder.Text = "Remove";
            this.buttonRemoveOrder.UseVisualStyleBackColor = true;
            this.buttonRemoveOrder.Click += new System.EventHandler(this.buttonRemoveOrder_Click);
            // 
            // buttonSendOrders
            // 
            this.buttonSendOrders.Location = new System.Drawing.Point(281, 361);
            this.buttonSendOrders.Name = "buttonSendOrders";
            this.buttonSendOrders.Size = new System.Drawing.Size(258, 43);
            this.buttonSendOrders.TabIndex = 10;
            this.buttonSendOrders.Text = "Send orders";
            this.buttonSendOrders.UseVisualStyleBackColor = true;
            this.buttonSendOrders.Click += new System.EventHandler(this.buttonSendOrders_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Result price:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(358, 342);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(14, 16);
            this.labelPrice.TabIndex = 12;
            this.labelPrice.Text = "0";
            // 
            // buttonPreviousOrders
            // 
            this.buttonPreviousOrders.Location = new System.Drawing.Point(634, 366);
            this.buttonPreviousOrders.Name = "buttonPreviousOrders";
            this.buttonPreviousOrders.Size = new System.Drawing.Size(154, 33);
            this.buttonPreviousOrders.TabIndex = 13;
            this.buttonPreviousOrders.Text = "See previous orders";
            this.buttonPreviousOrders.UseVisualStyleBackColor = true;
            this.buttonPreviousOrders.Click += new System.EventHandler(this.buttonPreviousOrders_Click);
            // 
            // RestaurantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPreviousOrders);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSendOrders);
            this.Controls.Add(this.buttonRemoveOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxOrders);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labelWelcome);
            this.Name = "RestaurantWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Application_Load);
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.ComboBox comboBoxDishes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Button buttonRemoveOrder;
        private System.Windows.Forms.Button buttonSendOrders;
        private System.Windows.Forms.Label labelResultOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button buttonPreviousOrders;
    }
}

