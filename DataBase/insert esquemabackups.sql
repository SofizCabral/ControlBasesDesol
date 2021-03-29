USE panelcontrolsql;

INSERT INTO esquemasbackup
(
  Intance
 ,BD
 ,BackupFullFrecDays
 ,DailyBackupDif
 ,FechaActualizacion
)
VALUES
(
  '' -- Intance - VARCHAR(45) NOT NULL
 ,'' -- BD - VARCHAR(45) NOT NULL
 ,0 -- BackupFullFrecDays - INT(11)
 ,0 -- DailyBackupDif - TINYINT(1)
 ,NOW() -- FechaActualizacion - DATETIME
);