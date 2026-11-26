CREATE TABLE users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    full_name VARCHAR(100) NOT NULL,
    gender VARCHAR(50),
    role VARCHAR(50),
    password VARCHAR(100) NOT NULL
);

CREATE TABLE labs (
    lab_id INT PRIMARY KEY IDENTITY(1,1),
    lab_name VARCHAR(50) NOT NULL
);

CREATE TABLE computers (
    computer_id INT PRIMARY KEY IDENTITY(1,1),
    pc_name VARCHAR(50) NOT NULL,
    lab_id INT,
    status VARCHAR(20) DEFAULT 'Available',
    FOREIGN KEY (lab_id) REFERENCES labs(lab_id)
);

CREATE TABLE software (
    software_id INT PRIMARY KEY IDENTITY(1,1),
    software_name VARCHAR(100) NOT NULL
);

CREATE TABLE pc_software (
    pc_software_id INT PRIMARY KEY IDENTITY(1,1),
    computer_id INT NOT NULL,
    software_id INT NOT NULL,
    FOREIGN KEY (computer_id) REFERENCES computers(computer_id),
    FOREIGN KEY (software_id) REFERENCES software(software_id)
);

CREATE TABLE schedules (
    schedule_id INT PRIMARY KEY IDENTITY(1,1),
    lab_id INT NOT NULL,
    user_id INT NOT NULL,
    subject VARCHAR(50) NOT NULL,
    section VARCHAR(10) NOT NULL,
    start_time DATETIME2 NOT NULL,
    end_time DATETIME2 NOT NULL,
    is_recurring BIT DEFAULT 1,
    day_of_week VARCHAR(10) NOT NULL,
    FOREIGN KEY (lab_id) REFERENCES labs(lab_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE issue_logs (
    log_id INT PRIMARY KEY IDENTITY(1,1),
    computer_id INT NOT NULL,
    lab_id INT NOT NULL,
    reported_by INT NOT NULL,
    description VARCHAR(500) NOT NULL,
    reported_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    resolved_at DATETIME2 NULL,
    FOREIGN KEY (computer_id) REFERENCES computers(computer_id),
    FOREIGN KEY (lab_id) REFERENCES labs(lab_id),
    FOREIGN KEY (reported_by) REFERENCES users(user_id),
    CHECK (resolved_at IS NULL OR resolved_at >= reported_at)
);


-- 1. Insert Users (Commas between rows, semicolon at the end)
INSERT INTO users (full_name, gender, role, password) VALUES
('Bill Bernando', 'Male', 'Teacher', 'bill123'),
('John Christian Lor', 'Male', 'Teacher', 'john123'),
('Dennis Nava', 'Male', 'Teacher', 'dennis123');

-- 2. Insert Labs
INSERT INTO labs (lab_name) VALUES
('Computer Lab 1'),
('Computer Lab 2'),
('Computer Lab 3'),
('EdTech 1'),
('EdTech 2');

-- 3. Insert Computers (25 PCs per lab)
-- Lab 1 (lab_id = 1)
INSERT INTO computers (pc_name, lab_id) VALUES
('LAB1-PC01', 1), ('LAB1-PC02', 1), ('LAB1-PC03', 1), ('LAB1-PC04', 1), ('LAB1-PC05', 1),
('LAB1-PC06', 1), ('LAB1-PC07', 1), ('LAB1-PC08', 1), ('LAB1-PC09', 1), ('LAB1-PC10', 1),
('LAB1-PC11', 1), ('LAB1-PC12', 1), ('LAB1-PC13', 1), ('LAB1-PC14', 1), ('LAB1-PC15', 1),
('LAB1-PC16', 1), ('LAB1-PC17', 1), ('LAB1-PC18', 1), ('LAB1-PC19', 1), ('LAB1-PC20', 1),
('LAB1-PC21', 1), ('LAB1-PC22', 1), ('LAB1-PC23', 1), ('LAB1-PC24', 1), ('LAB1-PC25', 1);

-- Lab 2 (lab_id = 2)
INSERT INTO computers (pc_name, lab_id) VALUES
('LAB2-PC01', 2), ('LAB2-PC02', 2), ('LAB2-PC03', 2), ('LAB2-PC04', 2), ('LAB2-PC05', 2),
('LAB2-PC06', 2), ('LAB2-PC07', 2), ('LAB2-PC08', 2), ('LAB2-PC09', 2), ('LAB2-PC10', 2),
('LAB2-PC11', 2), ('LAB2-PC12', 2), ('LAB2-PC13', 2), ('LAB2-PC14', 2), ('LAB2-PC15', 2),
('LAB2-PC16', 2), ('LAB2-PC17', 2), ('LAB2-PC18', 2), ('LAB2-PC19', 2), ('LAB2-PC20', 2),
('LAB2-PC21', 2), ('LAB2-PC22', 2), ('LAB2-PC23', 2), ('LAB2-PC24', 2), ('LAB2-PC25', 2);

-- Lab 3 (lab_id = 3)
INSERT INTO computers (pc_name, lab_id) VALUES
('LAB3-PC01', 3), ('LAB3-PC02', 3), ('LAB3-PC03', 3), ('LAB3-PC04', 3), ('LAB3-PC05', 3),
('LAB3-PC06', 3), ('LAB3-PC07', 3), ('LAB3-PC08', 3), ('LAB3-PC09', 3), ('LAB3-PC10', 3),
('LAB3-PC11', 3), ('LAB3-PC12', 3), ('LAB3-PC13', 3), ('LAB3-PC14', 3), ('LAB3-PC15', 3),
('LAB3-PC16', 3), ('LAB3-PC17', 3), ('LAB3-PC18', 3), ('LAB3-PC19', 3), ('LAB3-PC20', 3),
('LAB3-PC21', 3), ('LAB3-PC22', 3), ('LAB3-PC23', 3), ('LAB3-PC24', 3), ('LAB3-PC25', 3);

-- EdTech 1 (lab_id = 4)
INSERT INTO computers (pc_name, lab_id) VALUES
('EDTECH1-PC01', 4), ('EDTECH1-PC02', 4), ('EDTECH1-PC03', 4), ('EDTECH1-PC04', 4), ('EDTECH1-PC05', 4),
('EDTECH1-PC06', 4), ('EDTECH1-PC07', 4), ('EDTECH1-PC08', 4), ('EDTECH1-PC09', 4), ('EDTECH1-PC10', 4),
('EDTECH1-PC11', 4), ('EDTECH1-PC12', 4), ('EDTECH1-PC13', 4), ('EDTECH1-PC14', 4), ('EDTECH1-PC15', 4),
('EDTECH1-PC16', 4), ('EDTECH1-PC17', 4), ('EDTECH1-PC18', 4), ('EDTECH1-PC19', 4), ('EDTECH1-PC20', 4),
('EDTECH1-PC21', 4), ('EDTECH1-PC22', 4), ('EDTECH1-PC23', 4), ('EDTECH1-PC24', 4), ('EDTECH1-PC25', 4);

-- EdTech 2 (lab_id = 5)
INSERT INTO computers (pc_name, lab_id) VALUES
('EDTECH2-PC01', 5), ('EDTECH2-PC02', 5), ('EDTECH2-PC03', 5), ('EDTECH2-PC04', 5), ('EDTECH2-PC05', 5),
('EDTECH2-PC06', 5), ('EDTECH2-PC07', 5), ('EDTECH2-PC08', 5), ('EDTECH2-PC09', 5), ('EDTECH2-PC10', 5),
('EDTECH2-PC11', 5), ('EDTECH2-PC12', 5), ('EDTECH2-PC13', 5), ('EDTECH2-PC14', 5), ('EDTECH2-PC15', 5),
('EDTECH2-PC16', 5), ('EDTECH2-PC17', 5), ('EDTECH2-PC18', 5), ('EDTECH2-PC19', 5), ('EDTECH2-PC20', 5),
('EDTECH2-PC21', 5), ('EDTECH2-PC22', 5), ('EDTECH2-PC23', 5), ('EDTECH2-PC24', 5), ('EDTECH2-PC25', 5);


-- 3. Software (IDs 1 to 16)
INSERT INTO software (software_name) VALUES
('Microsoft Office'),
('Google Chrome'), 
('Visual Studio Code'),
('Python'),
('Java JDK'),
('SQL Server Management Studio'),
('Microsoft Excel'),
('Cisco Packet Tracer'),
('Microsoft Powerpoint'),
('VirtualBox'),
('Jetbrains'),
('Pycharm'),
('Spyder'),
('Autocad'),
('Notepad'),
('Notepad++');

-- 4. pc_software (Assign software IDs to each lab's computers)
INSERT INTO pc_software (computer_id, software_id)
SELECT c.computer_id, s.software_id
FROM computers c
JOIN software s ON 
    (c.lab_id = 1 AND s.software_id IN (1, 2, 3, 4, 5)) OR     -- Com Lab 1
    (c.lab_id = 2 AND s.software_id IN (1, 2, 3, 6, 7)) OR     -- Com Lab 2
    (c.lab_id = 3 AND s.software_id IN (1, 2, 8, 9, 10)) OR    -- Com Lab 3
    (c.lab_id = 4 AND s.software_id IN (1, 2, 11, 12, 13)) OR  -- Edtech 1
    (c.lab_id = 5 AND s.software_id IN (1, 2, 14, 15, 16));    -- Edtech 2

-- 5. Insert Schedules FIRST (Generates schedule_id 1 to 10)
INSERT INTO schedules
(lab_id, user_id, subject, section, day_of_week,
 start_time, end_time, is_recurring)
VALUES
-- Lab 1
(1, 1, 'CC102', 'BSIT 1-1', 'Monday', '08:00', '10:00', 1),
(1, 2, 'HCI101', 'BSIT 1-8', 'Monday', '10:30', '12:30', 1),

-- Lab 2
(2, 2, 'CC103', 'BSIT 1-12', 'Tuesday', '08:00', '11:00', 1),
(2, 3, 'IM101', 'BSIT 2-4', 'Tuesday', '13:00', '15:00', 1),

-- Lab 3
(3, 1, 'CC104', 'BSIT 2-9', 'Wednesday', '13:00', '16:00', 1),
(3, 3, 'CC102', 'BSIT 1-5', 'Wednesday', '08:00', '10:00', 1),

-- EdTech 1
(4, 2, 'HCI101', 'BSIT 1-14', 'Thursday', '09:00', '12:00', 1),
(4, 1, 'CC103', 'BSIT 1-3', 'Thursday', '13:00', '15:00', 1),

-- EdTech 2
(5, 3, 'IM101', 'BSIT 2-12', 'Friday', '08:00', '10:30', 1),
(5, 2, 'CC104', 'BSIT 2-2', 'Friday', '14:00', '17:00', 1);
