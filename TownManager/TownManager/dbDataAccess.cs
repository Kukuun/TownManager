using System;
using System.Data;
using System.Data.SQLite;

/// <summary>
/// Summary description for dbDataAccess
/// </summary>
public class dbDataAccess {
    //Creates the DataBase Variable
    private string connectionstring;
    private DataTable dt = new DataTable();

    //Sets the DataBase for Project
    private void SelectDatabase() {
        //Defines DataBase Variable.
        connectionstring = @" Data Source = DungeonManagerDB.db; Version = 3; FailIfMissing=False;";
    }
    
    public string InitializeDatabase() {
        SelectDatabase();

        string ReturnValue = string.Empty;

        SQLiteConnection con = new SQLiteConnection(connectionstring);

        try {
            con.Open();
            if (con.State == ConnectionState.Open) {
                ReturnValue = "Local Database is Connected Successfully!";
            }
        }
        catch (Exception ex) {
            ReturnValue = "Something went wrong with the Local Database... This is why: " + ex.Message;
        }

        return ReturnValue;
    }

    public DataTable GetData(SQLiteCommand cmd) {
        SelectDatabase();

        SQLiteConnection con = new SQLiteConnection(connectionstring);
        SQLiteDataAdapter objDa = new SQLiteDataAdapter();

        cmd.Connection = con;
        con.Open();
        objDa.SelectCommand = cmd;

        dt.Clear();
        objDa.Fill(dt);

        return dt;
    }

    public int intModifyData(SQLiteCommand cmd) {
        SelectDatabase();

        SQLiteConnection con = new SQLiteConnection(connectionstring);

        int nRows;

        cmd.Connection = con;
        con.Open();
        nRows = cmd.ExecuteNonQuery();
        con.Close();

        return nRows;
    }

    public void ModifyData(SQLiteCommand cmd) {
        SelectDatabase();

        SQLiteConnection con = new SQLiteConnection(connectionstring);

        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();

        con.Close();
    }

    public int GetScalarData(SQLiteCommand cmd) {
        SelectDatabase();

        SQLiteConnection con = new SQLiteConnection(connectionstring);

        int nNewId;

        cmd.Connection = con;
        con.Open();
        nNewId = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();

        return nNewId;
    }
}