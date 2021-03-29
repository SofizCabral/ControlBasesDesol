USE panelcontrolsql;

INSERT INTO ultimosbackups
(
  Intance
 ,`database`
 ,FechaBackup
 ,BackupSizeMB
 ,BackupType
 ,backupFile
 ,RecoveryModel
 ,IsCopyOnly
 ,FechaActualizacion
 ,UltimosBackupscol
)
VALUES
(
  '' -- Intance - VARCHAR(45)
 ,'' -- database - VARCHAR(45)
 ,NOW() -- FechaBackup - DATETIME
 ,0 -- BackupSizeMB - FLOAT
 ,'' -- BackupType - VARCHAR(15)
 ,'' -- backupFile - VARCHAR(500)
 ,'' -- RecoveryModel - VARCHAR(15)
 ,0 -- IsCopyOnly - TINYINT(1)
 ,NOW() -- FechaActualizacion - DATETIME
 ,'' -- UltimosBackupscol - VARCHAR(45)
);