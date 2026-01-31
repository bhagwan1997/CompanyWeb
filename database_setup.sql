        -- database_setup.sql file content
        -- Departments table with AUTOINCREMENT
        CREATE TABLE departments (
        department_id INTEGER PRIMARY KEY AUTOINCREMENT,
        department_name TEXT NOT NULL
        );
        -- Insert department data
        INSERT INTO departments (department_name)
        VALUES
        ('Sales'),
        ('Engineering'),
        ('Marketing');
        -- Employees table with foreign key to departments
        CREATE TABLE employees (
        employee_id INTEGER PRIMARY KEY AUTOINCREMENT,
        first_name TEXT NOT NULL,
        last_name TEXT NOT NULL,
        department_id INTEGER,
        FOREIGN KEY (department_id) REFERENCES departments(department_id)
        );
        -- Insert some sample data
        INSERT INTO employees (first_name, last_name, department_id) VALUES ('Sam', 'Fox', 1);
        INSERT INTO employees (first_name, last_name, department_id) VALUES ('Jan', 'Lee', 2);
        INSERT INTO employees (first_name, last_name, department_id) VALUES ('Ann', 'Fay', 3);
        INSERT INTO employees (first_name, last_name, department_id) VALUES ('Tom', 'Day', 2);