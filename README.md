
# HSPA (Angular .NET Project)

Welcome to the Angular .NET Project! This project is designed to demonstrate the integration of Angular as the frontend framework and ASP.NET Core as the backend API. It showcases best practices such as using Angular route resolvers, the AutoMapper library for object-object mapping, retry mechanisms for HTTP requests, the repository pattern for data access.

## Live Demo

- **Hosted Frontend Link**: [hspa-angular-16.web.app](https://hspa-angular-16.web.app/)
- **Alternative Link**: [hspa-angular-16.firebaseapp.com](https://hspa-angular-16.firebaseapp.com/)

## Features

### Frontend (Angular)
- **Angular 16 with Route Resolvers**: Ensures data is preloaded before a route is activated, enhancing user experience by avoiding loading indicators.
- **Retry Mechanism**: Automatically retries failed HTTP requests when the status code is `0`, improving robustness in case of network failures.
- **File Upload**: This application utilizes the `ng2-file-upload` package for seamless file upload capabilities with a clean and intuitive UI.

### Backend (ASP.NET Core)
- **Repository Pattern**: Encapsulating data access logic promotes a clean separation of concerns and a maintainable codebase.
- **AutoMapper**: Simplifies mapping between objects, reducing manual code for property assignments.

## Prerequisites

Ensure you have the following installed:
- [Node.js](https://nodejs.org/) (LTS version recommended)
- [Angular CLI](https://angular.io/cli)
- [Visual Studio or Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Firebase CLI](https://firebase.google.com/docs/cli)

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/yourusername/your-angular-net-project.git
cd your-angular-net-project
```

### Frontend Setup
1. Navigate to the frontend directory:
   ```bash
   cd client
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Run the Angular development server:
   ```bash
   ng serve
   ```
   The application will be accessible at `http://localhost:4200/`.

### Backend Setup
1. Navigate to the backend directory:
   ```bash
   cd server
   ```
2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
3. Run the ASP.NET Core application:
   ```bash
   dotnet run
   ```
   The API will be accessible at `https://localhost:5001/` (or a similar port).

## GitHub Actions Workflow

### Automated Deployment to Firebase
This project uses GitHub Actions to automate the frontend's deployment to Firebase Hosting. The workflow file is located in `.github/workflows/deploy.yml`.

**Steps to set up the GitHub workflow**:
1. Create a Firebase project and link it to your GitHub repository.
2. Add the `FIREBASE_SERVICE_ACCOUNT_KEY` secret in GitHub for authentication.
3. Modify the workflow file as needed for your environment.

### Sample Workflow Configuration
```yaml
name: Deploy to Firebase Hosting
on:
  push:
    branches:
      - main

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout Repository
      uses: actions/checkout@v3

    - name: Setup Node.js
      uses: actions/setup-node@v3
      with:
        node-version: '16'

    - name: Install Dependencies
      run: npm ci
      working-directory: ./client

    - name: Build Project
      run: npm run build -- --prod
      working-directory: ./client

    - name: Deploy to Firebase
      uses: w9jds/firebase-action@v2.4.0
      with:
        args: deploy --only hosting
      env:
        FIREBASE_SERVICE_ACCOUNT_KEY: ${{ secrets.FIREBASE_SERVICE_ACCOUNT_KEY }}
```

## Key Libraries and Packages

### Angular
- **`ng2-file-upload`**: A robust Angular package for handling file uploads.
- **`rxjs`**: Used for retry logic and other reactive programming tasks.

### ASP.NET Core
- **AutoMapper**: Simplifies object-to-object mapping.
- **Repository Pattern**: Ensures clean architecture and maintainable data access layers.

## Deployment

### Deploying to Firebase Manually
1. Build the Angular project:
   ```bash
   ng build --prod
   ```
2. Deploy using Firebase CLI:
   ```bash
   firebase deploy
   ```

## Contributing

Contributions are welcome! Please fork this repository and submit pull requests for any new features or bug fixes.

## Acknowledgements

A special thank you to the creator of the YouTube tutorial that inspired and guided this project. Your step-by-step explanations and insights were invaluable in helping bring this project to life.

---

Thank you for checking out this project! Feel free to explore, contribute, and reach out with any questions.
