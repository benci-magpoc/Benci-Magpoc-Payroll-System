// Initializing namespaces to be used
using System.Data.OleDb;
using System.Net;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{
    // This function gets the user activity from the tblUserActivity
    public static dsUserActivity GetUserActivity(string Database)
    {
        // Initializing objects
        dsUserActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // assigning new OleDbConnection class to sqlConn object
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
        // assigning new OleDbDataAdapter class to sqlDA object
        sqlDA = new OleDbDataAdapter("select * from tblUserActivity", sqlConn);
        // assigning new dsUserActivity class to DS object
        DS = new dsUserActivity();
        // fills sqlDA 
        sqlDA.Fill(DS.tblUserActivity);
        // return appropriate dsUserActivity value
        return DS;
    }

    // This function saves the user activity
    public static void SaveUserActivity(string Database, string FormAccessed)
    {
        // constructing new OleDbConnection object
        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        string strSQL;
        strSQL = "Insert into tblUserActivity (UserIP, FormAccessed) values ('" +
        GetIP4Address() + "', '" + FormAccessed + "')";
        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }

    // This function gets the IP Address
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;
        foreach (IPAddress IPA in
        Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }
        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        return IP4Address;
    }

    public clsDataLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool SaveUser(string Database, string UserName, string Password,
    string SecurityLevel)
    {
        bool userSaved;
        OleDbTransaction myTransaction = null;
        try
        {
            // creating connection to a database through object conn of the OleDbConnection class
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Database);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
            // assigning BeginTransaction method to myTransaction object
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;
            // assigning SQL commands to strSQL variable in order to be written to the database
            strSQL = "Insert into tblUserLogin " +
            "(UserName, UserPassword, SecurityLevel) values ('" +
            UserName + "', '" + Password + "', '" + SecurityLevel + "')";
            // setting how the command will be interpreted which is .text
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // executes the strSQL statement to the connected database
            command.ExecuteNonQuery();
            // Update SQL command is used to modify record in the table tblPersonnel
            strSQL = "Update tblUserLogin " +
            "Set UserName='" + UserName + "', " +
            "UserPassword='" + Password + "', " +
            "SecurityLevel='" + SecurityLevel + "' " +
            "Where UserID=(Select Max(UserID) From tblUserLogin)";
            // setting how the command will be interpreted which is .text
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // executes the strSQL statement to the connected database
            command.ExecuteNonQuery();
            // executing Commit method for myTransaction object
            myTransaction.Commit();
            // close command is used to close existing connection and recordsaved is assigned with true value
            conn.Close();
            userSaved = true;
        }
        catch (Exception ex)
        {
            // rolling back the transaction if it receives an input error
            myTransaction.Rollback();
            userSaved = false;
        }
        return userSaved;

    }
    // This function saves the personnel data
    public static bool SavePersonnel(string Database, string FirstName, string LastName,
    string PayRate, string StartDate, string EndDate)
    {
        bool recordSaved;
        // creating new transaction object myTransaction
        OleDbTransaction myTransaction = null;
        try
        {
            // creating connection to a database through object conn of the OleDbConnection class
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Database);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
            // assigning BeginTransaction method to myTransaction object
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;
            // assigning SQL commands to strSQL variable in order to be written to the database
            strSQL = "Insert into tblPersonnel " +
           "(FirstName, LastName) values ('" +
            FirstName + "', '" + LastName + "')";
            // setting how the command will be interpreted which is .text
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // executes the strSQL statement to the connected database
            command.ExecuteNonQuery();
            // Update SQL command is used to modify record in the table tblPersonnel
            strSQL = "Update tblPersonnel " +
            "Set PayRate=" + PayRate + ", " +
            "StartDate='" + StartDate + "', " +
            "EndDate='" + EndDate + "' " +
            "Where ID=(Select Max(ID) From tblPersonnel)";
            // setting how the command will be interpreted which is .text
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // executes the strSQL statement to the connected database
            command.ExecuteNonQuery();
            // executing Commit method for myTransaction object
            myTransaction.Commit();
            // close command is used to close existing connection and recordsaved is assigned with true value
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            // rolling back the transaction if it receives an input error
            myTransaction.Rollback();
            recordSaved = false;
        }
        return recordSaved;
    }

    public static dsPersonnel GetPersonnel(string Database, string strSearch)
    {
        // Initializing objects
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // assigning new OleDbConnection class to sqlConn object
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);

        if (strSearch == null || strSearch.Trim() == "")
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel", sqlConn);
        }
        else
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel where LastName = '" + strSearch + "'", sqlConn);
        }
        
        // assigning new OleDbDataAdapter class to sqlDA object
        //sqlDA = new OleDbDataAdapter("select * from tblPersonnel", sqlConn);
        // assigning new dsUserActivity class to DS object
        DS = new dsPersonnel();
        // fills sqlDA 
        sqlDA.Fill(DS.tblPersonnel);
        // return appropriate dsUserActivity value
        return DS;
    }

    // This function verifies a user in the tblUser table
    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        // creating objects
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // connecting database using sqlConn object
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        // assigning data adapter to sqlDA object
        sqlDA = new OleDbDataAdapter("Select SecurityLevel from tblUserLogin " +
        "where UserName like '" + UserName + "' " +
        "and UserPassword like '" + UserPassword + "'", sqlConn);
        // assigning new dsUser to DS object
        DS = new dsUser();
        // filling userlogin data to adapter
        sqlDA.Fill(DS.tblUserLogin);
        // returning dsUser object
        return DS;
    }
}