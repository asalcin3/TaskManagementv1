# Task Management System

This is a **Task Management System** built using **ASP.NET 9 Web API** for the backend and **Vue.js with the Composition API, Pinia for state management, and DevExtreme UI components** for the frontend.
It is a simple CRUD application with integrated Brevo(SendinBlue) for sending emails.
## 🚀 Technologies Used
### **Backend: ASP.NET 9 Web API**
- **Authentication & Authorization:** JWT-based authentication
- **Database:** SQL database
- **ORM:** Entity Framework Core

**Frontend: Vue 3 with Composition API**
- **State Management:** Pinia
- **UI Components:** DevExtreme (DataGrid, DateBox, TagBox, CheckBox, etc.)
- **Routing:** Vue Router
- **HTTP Client:** Axios

**Backend Setup**
1. Clone the repository
   git clone https://github.com/your-repo/task-management.git
   cd TaskManagementSystem

2. Restore dependencies
    dotnet restore
3. Update database & apply migrations
    dotnet ef database update
4. Run the API

   
 **Frontend Setup**
   1. Navigate to the frontend directory

      - TaskManagementSystem/taskmanagementclient
      
   2. Install dependencies
      
         - npm install
      
   3. Start Vue app
      
        - npm run serve
        

   
