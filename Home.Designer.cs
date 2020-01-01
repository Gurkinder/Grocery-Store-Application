namespace GroupProject
{
    partial class Home
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shoppingCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.fruitsAndVegetablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diaryAndEggsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FruitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naturalAndOrganicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meatAndSeafoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frozenFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliAndFreshMealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerealAndBreakfastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bakeryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pantryFoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Store";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.shoppingCartToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(788, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(190, 485);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 32);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // shoppingCartToolStripMenuItem
            // 
            this.shoppingCartToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingCartToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.shoppingCartToolStripMenuItem.Name = "shoppingCartToolStripMenuItem";
            this.shoppingCartToolStripMenuItem.Size = new System.Drawing.Size(177, 32);
            this.shoppingCartToolStripMenuItem.Text = "Customer\'s Page";
            this.shoppingCartToolStripMenuItem.Click += new System.EventHandler(this.ShoppingCartToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(177, 32);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(177, 32);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(212, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(563, 268);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fruitsAndVegetablesToolStripMenuItem,
            this.diaryAndEggsToolStripMenuItem,
            this.FruitsToolStripMenuItem,
            this.naturalAndOrganicToolStripMenuItem,
            this.meatAndSeafoodToolStripMenuItem,
            this.frozenFoodToolStripMenuItem,
            this.deliAndFreshMealsToolStripMenuItem,
            this.cerealAndBreakfastToolStripMenuItem,
            this.bakeryToolStripMenuItem,
            this.pantryFoodsToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(195, 485);
            this.menuStrip3.TabIndex = 9;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // fruitsAndVegetablesToolStripMenuItem
            // 
            this.fruitsAndVegetablesToolStripMenuItem.Enabled = false;
            this.fruitsAndVegetablesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fruitsAndVegetablesToolStripMenuItem.Name = "fruitsAndVegetablesToolStripMenuItem";
            this.fruitsAndVegetablesToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.fruitsAndVegetablesToolStripMenuItem.Text = "CATEGORIES";
            // 
            // diaryAndEggsToolStripMenuItem
            // 
            this.diaryAndEggsToolStripMenuItem.Name = "diaryAndEggsToolStripMenuItem";
            this.diaryAndEggsToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.diaryAndEggsToolStripMenuItem.Text = "Diary and Eggs";
            this.diaryAndEggsToolStripMenuItem.Click += new System.EventHandler(this.DiaryAndEggsToolStripMenuItem_Click);
            // 
            // FruitsToolStripMenuItem
            // 
            this.FruitsToolStripMenuItem.CheckOnClick = true;
            this.FruitsToolStripMenuItem.Name = "FruitsToolStripMenuItem";
            this.FruitsToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.FruitsToolStripMenuItem.Text = "Fruits and Vegetables";
            this.FruitsToolStripMenuItem.Click += new System.EventHandler(this.PantryFoodToolStripMenuItem_Click);
            // 
            // naturalAndOrganicToolStripMenuItem
            // 
            this.naturalAndOrganicToolStripMenuItem.Name = "naturalAndOrganicToolStripMenuItem";
            this.naturalAndOrganicToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.naturalAndOrganicToolStripMenuItem.Text = "Natural and Organic";
            this.naturalAndOrganicToolStripMenuItem.Click += new System.EventHandler(this.NaturalAndOrganicToolStripMenuItem_Click);
            // 
            // meatAndSeafoodToolStripMenuItem
            // 
            this.meatAndSeafoodToolStripMenuItem.Name = "meatAndSeafoodToolStripMenuItem";
            this.meatAndSeafoodToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.meatAndSeafoodToolStripMenuItem.Text = "Meat and Seafood";
            this.meatAndSeafoodToolStripMenuItem.Click += new System.EventHandler(this.MeatAndSeafoodToolStripMenuItem_Click);
            // 
            // frozenFoodToolStripMenuItem
            // 
            this.frozenFoodToolStripMenuItem.Name = "frozenFoodToolStripMenuItem";
            this.frozenFoodToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.frozenFoodToolStripMenuItem.Text = "Frozen Food";
            this.frozenFoodToolStripMenuItem.Click += new System.EventHandler(this.FrozenFoodToolStripMenuItem_Click);
            // 
            // deliAndFreshMealsToolStripMenuItem
            // 
            this.deliAndFreshMealsToolStripMenuItem.Name = "deliAndFreshMealsToolStripMenuItem";
            this.deliAndFreshMealsToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.deliAndFreshMealsToolStripMenuItem.Text = "Deli and Fresh meals";
            this.deliAndFreshMealsToolStripMenuItem.Click += new System.EventHandler(this.DeliAndFreshMealsToolStripMenuItem_Click);
            // 
            // cerealAndBreakfastToolStripMenuItem
            // 
            this.cerealAndBreakfastToolStripMenuItem.Name = "cerealAndBreakfastToolStripMenuItem";
            this.cerealAndBreakfastToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.cerealAndBreakfastToolStripMenuItem.Text = "Cereal and Breakfast";
            this.cerealAndBreakfastToolStripMenuItem.Click += new System.EventHandler(this.CerealAndBreakfastToolStripMenuItem_Click);
            // 
            // bakeryToolStripMenuItem
            // 
            this.bakeryToolStripMenuItem.Name = "bakeryToolStripMenuItem";
            this.bakeryToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.bakeryToolStripMenuItem.Text = "Bakery";
            this.bakeryToolStripMenuItem.Click += new System.EventHandler(this.BakeryToolStripMenuItem_Click);
            // 
            // pantryFoodsToolStripMenuItem
            // 
            this.pantryFoodsToolStripMenuItem.Name = "pantryFoodsToolStripMenuItem";
            this.pantryFoodsToolStripMenuItem.Size = new System.Drawing.Size(182, 25);
            this.pantryFoodsToolStripMenuItem.Text = "Pantry Foods";
            this.pantryFoodsToolStripMenuItem.Click += new System.EventHandler(this.PantryFoodsToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Check out our top Selling Products";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 485);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shoppingCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem fruitsAndVegetablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diaryAndEggsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FruitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naturalAndOrganicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meatAndSeafoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frozenFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliAndFreshMealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerealAndBreakfastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bakeryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pantryFoodsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}