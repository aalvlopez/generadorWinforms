using System;
using System.Collections; 
using System.Windows.Forms;

public class form : Form
{
    public form()
    {
		CreateMyListView();
    }

    // Groups the items using the groups created for the clicked 
    // column.
    private void CreateMyListView()
		{
			// Create a new ListView control.
			ListView listView1 = new ListView();
		listView1.Dock=DockStyle.Fill;
			// Set the view to show details.
			listView1.View = View.Tile;
			// Allow the user to edit item text.
			listView1.LabelEdit = true;
			// Allow the user to rearrange columns.
			listView1.AllowColumnReorder = true;
			// Display check boxes.
//			listView1.CheckBoxes = true;
			// Select the item and subitems when selection is made.
			listView1.FullRowSelect = true;
			// Display grid lines.
			listView1.GridLines = true;
			// Sort the items in the list in ascending order.
			listView1.Sorting = SortOrder.Ascending;
            			
			// Create three items and three sets of subitems for each item.
			ListViewItem item1 = new ListViewItem("item1");
			// Place a check mark next to the item.
			item1.Checked = true;
			item1.SubItems.Add("1");
			item1.SubItems.Add("2");
			item1.SubItems.Add("3");
			ListViewItem item2 = new ListViewItem("item2");
			item2.SubItems.Add("4");
			item2.SubItems.Add("5");
			item2.SubItems.Add("6");
			ListViewItem item3 = new ListViewItem("item3");
			// Place a check mark next to the item.
			item3.Checked = true;
			item3.SubItems.Add("7");
			item3.SubItems.Add("8");
			item3.SubItems.Add("9");

			// Create columns for the items and subitems.
			// Width of -2 indicates auto-size.
			listView1.Columns.Add("Item Column");
			listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 3",-2);
//			listView1.Columns.Add("Column 4");

			//Add the items to the ListView.
            		listView1.Items.AddRange(new ListViewItem[]{item1,item2,item3});

			// Create two ImageList objects.
			ImageList imageListSmall = new ImageList();
			ImageList imageListLarge = new ImageList();


			//Assign the ImageList objects to the ListView.
			listView1.LargeImageList = imageListLarge;
			listView1.SmallImageList = imageListSmall;

			// Add the ListView to the control collection.
			this.Controls.Add(listView1);
		}

}
