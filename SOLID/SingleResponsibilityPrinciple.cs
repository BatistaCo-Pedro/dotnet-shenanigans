namespace SOLID;

public class ClassWithTooMuchResponsibility
{
    public void ConnectToDatabase(string connectionString)
    {
        // logic to connect to database
    }

    public void SetupDatabase(string options)
    {
        // logic to setup database
    }

    public void DisconnectFromDatabase()
    {
        // logic to disconnect from database
    }

    public void CreateUser()
    {
        // logic to create user
    }

    public void CreateRole()
    {
        // logic to create role
    }
    
    public void AssignRoleToUser()
    {
        // logic to assign role to user
    }
}

// -- Better approach --

public class DatabaseManager
{
    public void ConnectToDatabase(string connectionString)
    {
        // logic to connect to database
    }

    public void SetupDatabase(string options)
    {
        // logic to setup database
    }

    public void DisconnectFromDatabase()
    {
        // logic to disconnect from database
    }
}

public class UserManager
{
    public void CreateUser()
    {
        // logic to create user
    }

    public void CreateRole()
    {
        // logic to create role
    }
    
    public void AssignRoleToUser()
    {
        // logic to assign role to user
    }
}