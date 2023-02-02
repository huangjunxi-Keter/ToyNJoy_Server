# 记录

- EFCore
  - 生成模型

     ``` bash
     Scaffold-DbContext "Data Source=localhost;Initial Catalog=ToyNJoy;User ID=sa;Password=sa;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;" 
     Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
     ```

  - 更新模型

     ``` bash
     Scaffold-DbContext "Data Source=localhost;Initial Catalog=ToyNJoy;User ID=sa;Password=sa;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;" 
     Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model -Force
     ```
