# Malshinon

![Destroyed Gaza scene](ChatGPT%20Image%20Jun%2013,%202025,%2002_25_31%20AM.png)

**Malshinon** – A simple intelligence-reporting console app built in C# with MySQL integration.

## 🔎 Description

Malshinon enables users to submit, store, and manage intelligence reports.  
Reports link informants (`Malshinim`) and targets, log timestamps, and calculate metrics such as mentions and reports count.

## ⚙️ Features

- Interactive console UI for submitting intelligence reports  
- Separates concerns into manager classes:  
  - `MalshinimManager`, `TargetsManager`, `ReportsManager`, `RealThreatsManager`  
- CRUD operations on `people`, `reports`, and `real_threats` tables  
- MySQL database integration via parameterized queries  
- Input parsing, validation, and exception handling  
- Calculation of time differences between reports

## 🏗️ Architecture

- **DAL** – Data Access Layer for secure DB operations using parameterized `MySqlCommand`  
- **Models** – Data models (e.g. `Person`, `IntelReport`)  
- **Managers** – Handle prompts, lookups, and business logic per entity  
- **Program.cs** – Entry point, orchestrates user workflow via `AddingReports`

## 🛠️ Setup

### Requirements

- .NET Framework (or .NET Core)  
- MySQL server  
- `people`, `reports`, `real_threats` tables created (see `malshinon.sql`)  
- `MySql.Data` NuGet package

### Installation

1. Clone the repo  
2. Configure App.config with MySQL connection string  
3. Build in Visual Studio  
4. Run and follow console prompts to submit reports

## 📝 SQL Schema

See `malshinon.sql` for the SQL definitions of tables:
- `people` (informants & targets)  
- `reports` (IntelReport)  
- `real_threats`

### Foreign Keys Example

```sql
ALTER TABLE reports
ADD FOREIGN KEY (reporter_id) REFERENCES people(id),
ADD FOREIGN KEY (target_id)   REFERENCES people(id);

ALTER TABLE real_threats
ADD FOREIGN KEY (target_id) REFERENCES people(id) ON DELETE CASCADE;

🔐 Best Practices
Uses parameterized queries to prevent SQL injection

Avoids global mutable state in DAL methods

Uses Math.Ceiling, TimeSpan, OrderByDescending to compute and sort report intervals

🧪 Usage
Run the application

Enter informant’s full name, target’s full name, and report text

System prompts for confirmation and saves to DB

Reports can be listed, sorted by most recent

🛠️ Development
Add more filtering/reporting features

Implement update/delete for reports or people

Extend RealThreatsManager for automated threat logging

Improve input validation and logging

🤝 Contributing
Feel free to open issues or PRs. Please follow clean code standards and add tests for new features.

Enjoy using Malshinon, and thanks for checking it out! 🚀


---

This README covers:
- Project overview
- Usage & setup steps
- Architecture outline
- SQL schema hints
- Tips and contribution instructions

Let me know if you'd like help with more details—screenshots, dependency versions, or releasing via GitHub Releases!
::contentReference[oaicite:0]{index=0}

