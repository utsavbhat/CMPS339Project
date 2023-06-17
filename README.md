# CMPS339Project

# Navigate to the reactapp folder and do the npm install. 

The Connection string needs to be changed to the localdb server name. 
For instance the current connection string in the appsetting.json file is this: 

"ConnectionStrings": {
    "SqlConnection": "server=LAPTOP-EOP88J19\\SQLEXPRESS; database=CMPS_339_AmusementPark; Integrated Security=true; Encrypt=false"
  },
  
  Change the server='...'; value to the one where the localdb ssms server name. 

# To Create the Database
Copy and paste the script from sqlscript.txt file into the ssms new query. After pasting the script, click on the execute then it should create the database with all the tables that is required for the project.
