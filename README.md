# Digital_Banking

# 💳 Digital Banking API (.NET 6)

A simple banking API built with ASP.NET Core 6 and Entity Framework Core. It supports operations like deposits, withdrawals, transfers, balance history tracking, daily transaction limits, and transaction fee calculations.

---

## 🚀 How to Run the API

### ✅ Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQL Server or SQL Server Express
- [Postman](https://www.postman.com/) or `curl` for testing

### 💠 Setup Steps

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-repo/digital-banking-api.git
   cd digital-banking-api
   ```

2. **Configure the Database Connection** Edit `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=BankingDb;Trusted_Connection=True;"
   }
   ```

3. **Apply EF Core Migrations**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the API**

   ```bash
   dotnet run
   ```

5. Visit Swagger UI at:

   ```
   https://localhost:7044/swagger
   ```

---

## 🖁 Sample API Calls

### 👤 Customer Endpoints

#### ➕ Create Customer

```bash
curl -X POST https://localhost:7044/api/Customers \
  -H "Content-Type: application/json" \
  -d '{"firstName":"Juan","lastName":"Dela Cruz","email":"juan@example.com","phone":"09123456789"}'
```

#### 📋 Get All Customers

```bash
curl https://localhost:7044/api/Customers
```

#### 📄 Get Customer by ID

```bash
curl https://localhost:7044/api/Customers/1
```

### 💼 Account Endpoints

#### ➕ Create Account

```bash
curl -X POST https://localhost:7044/api/Accounts \
  -H "Content-Type: application/json" \
  -d '{"customerId":1,"accountType":"Savings"}'
```

#### 📋 Get All Accounts

```bash
curl https://localhost:7044/api/Accounts
```

#### 📄 Get Account by ID

```bash
curl https://localhost:7044/api/Accounts/1
```

#### ✅ Update Account Status

```bash
curl -X PUT https://localhost:7044/api/Accounts/status \
  -H "Content-Type: application/json" \
  -d '{"accountNumber":"10000001", "isActive": false}'
```

### 💳 Transaction Endpoints

#### 📅 Deposit

```bash
curl -X POST https://localhost:7044/api/Transactions/deposit \
  -H "Content-Type: application/json" \
  -d '{"accountNumber":"10000001","amount":1000,"description":"Initial deposit"}'
```

#### 📄 Withdraw

```bash
curl -X POST https://localhost:7044/api/Transactions/withdraw \
  -H "Content-Type: application/json" \
  -d '{"accountNumber":"10000001","amount":500,"description":"ATM withdraw"}'
```

#### 🔄 Transfer

```bash
curl -X POST https://localhost:7044/api/Transactions/transfer \
  -H "Content-Type: application/json" \
  -d '{"fromAccount":"10000001","toAccount":"10000002","amount":200,"description":"Send money"}'
```

#### 📜 Transaction History

```bash
curl https://localhost:7044/api/Transactions/history/10000001
```

#### 🔍 Search Transactions (by amount or description)

```bash
curl "https://localhost:7044/api/Transactions/search?accountNumber=10000001&amount=500"
curl "https://localhost:7044/api/Transactions/search?accountNumber=10000001&description=deposit"
```

### 📈 Balance History Endpoints

#### 📊 Get Balance History

```bash
curl https://localhost:7044/api/Transactions/balance-history/10000001
```

#### 📤 Export Balance History (CSV / PDF)

```bash
curl https://localhost:7044/api/Transactions/balance-history/export/10000001?format=csv
curl https://localhost:7044/api/Transactions/balance-history/export/10000001?format=pdf
```

---

## 📃 Database Schema Overview

### 🧝 Customer

| Field       | Type     |
| ----------- | -------- |
| Id          | int (PK) |
| FirstName   | string   |
| LastName    | string   |
| Email       | string   |
| Phone       | string   |
| CreatedDate | datetime |

### 💼 Account

| Field         | Type            |
| ------------- | --------------- |
| Id            | int (PK)        |
| AccountNumber | string (unique) |
| CustomerId    | int (FK)        |
| AccountType   | string          |
| Balance       | decimal(18,2)   |
| DailyLimit    | decimal(18,2)   |
| IsActive      | bool            |
| CreatedDate   | datetime        |

### 💸 Transaction

| Field           | Type          |
| --------------- | ------------- |
| Id              | int (PK)      |
| FromAccountId   | int (FK)      |
| ToAccountId     | int? (FK)     |
| Amount          | decimal(18,2) |
| TransactionType | string        |
| Description     | string        |
| Timestamp       | datetime      |
| Status          | string        |

### 📈 BalanceHistory

| Field         | Type          |
| ------------- | ------------- |
| Id            | int (PK)      |
| AccountId     | int (FK)      |
| Balance       | decimal(18,2) |
| Timestamp     | datetime      |
| TransactionId | int? (FK)     |

---

## 📌 Business Assumptions

1. **Daily Transaction Limit**

   - Each account has a `DailyLimit` to restrict total outgoing transactions per day.
   - Transactions exceeding this amount return a 400 error.

2. **Transaction Fees**

   - A flat or tiered transaction fee is applied (e.g., transfer fees).

3. **Balance History Tracking**

   - Balance snapshots are recorded after every transaction and can be exported.

4. **Inactive Accounts**

   - Accounts marked as `IsActive = false` are blocked from transactions.

5. **Unique Account Numbers**

   - AccountNumber field is unique and indexed.

6. **Currency**

   - All currency is represented in Philippine Peso (₱) using `decimal(18,2)` format.

---

## ⚠️ Error Response Samples

### 🚫 400 Bad Request – Daily Transaction Limit Exceeded

```json
{
  "message": "Daily transaction limit exceeded. You can still transact ₱2000.00 today."
}
```

### 🔒 403 Forbidden – Inactive Account

```json
{
  "message": "Account 10000001 is inactive and cannot perform transactions."
}
```

### 🧾 404 Not Found – Account Not Found

```json
{
  "message": "Account with ID 99999 not found."
}
```

### 📉 400 Bad Request – Insufficient Balance

```json
{
  "message": "Insufficient balance to complete the transaction."
}
```

### 📄 500 Internal Server Error – Unexpected Exception

```json
{
  "message": "An unexpected error occurred. Please contact support."
}
```

---

## 📂 Postman Collection

You can import the `DigitalBankingAPI.postman_collection.json` file into Postman for easy testing.

---

## ✅ License

This project is open-source and free to use for educational or non-commercial projects.

