-- Query tarea generada por nombres
SELECT
    t.iIDTask,
    q.iIDRethusQuerys,
    -- q.tIdentificationNumber,
    -- q.iIDRethusIdentificationType,
    q.tFirstName, q.tSecondName, q.tLastName, q.tSecondLastName,
    tt.tTaskTypeName as TipoTarea,
    t.iIDTaskType,
    sm2.tDescription as EstadoTarea,
    t.iIDTaskState,
    sm.tDescription as EstadoConsulta,
    q.iIDQueryState,
    q.iIDSearchType,
    st.tSearchTypeDescription as TipoBusqueda,
    t.iIDAssignedRobot,
    t.dtInitalDate
FROM rethus.tblRethusTasks t
    JOIN rethus.tblRethusQuerys q
    ON q.iIDTask = t.iIDTask
    JOIN rethus.tblSearchTypes st
    ON q.iIDSearchType = st.iIDSearchType
    JOIN rethus.tblTaskTypes tt
    ON t.iIDTaskType = tt.iIDTaskType
    JOIN rethus.tblStatesMachine sm
    ON q.iIDQueryState = sm.iIDStateMachine
    JOIN rethus.tblStatesMachine sm2
    ON t.iIDTaskState = sm2.iIDStateMachine
WHERE q.iIDSearchType = 2
ORDER BY t.iIDTask DESC

-- Datos main con Querys con nombre
SELECT *
FROM rethus.tblRethusData_Main m
    JOIN rethus.tblRethusQuerys rq
    ON m.iIDRethusQuery = rq.iIDRethusQuerys
WHERE rq.tFirstName IS NOT NULL

-- Querys donde el primer nombre o el primer apellido no es nulo y su estado es completado
SELECT *
FROM rethus.tblRethusQuerys
WHERE 
    (tFirstName IS NOT NULL
    OR tLastName IS NOT NULL)
    AND iIDQueryState = 7
GO

-- Querys donde con estado por hacer
SELECT *
FROM rethus.tblRethusQuerys
WHERE 
    iIDQueryState = 5
GO

-- Tasks con estado por hacer
SELECT *
FROM rethus.tblRethusTasks
WHERE 
    iIDTaskState = 1
GO

-- Update rows in table 'tblRethusQuerys'
UPDATE rethus.tblRethusQuerys
SET
    iIDQueryState = 7
    -- add more columns and values here
WHERE iIDQueryState = 5	/* add search conditions here */
GO

-- Tipos de identificacion en querys
SELECT DISTINCT m.tTipoIdentificacion
FROM rethus.tblRethusQuerys q 
JOIN rethus.tblRethusData_Main m
ON q.iIDRethusQuerys = m.iIDRethusQuery
GO

-- Select rows from a Table or View 'tblRetusQuerys' in schema 'rethus'
SELECT q.iIDTask, q.iIDSearchType, s.tSearchTypeDescription FROM rethus.tblRethusQuerys q
JOIN rethus.tblSearchTypes s
ON q.iIDSearchType =  s.iIDSearchType
WHERE iIDQueryState <> 7	/* add search conditions here */
GO

-- Select rows from a Table or View 'tblRetusQuerys' in schema 'rethus'
SELECT * FROM rethus.tblRethusTasks
WHERE iIDTaskState <> 3	/* add search conditions here */
GO

-- Update rows in table 'rethus.tblRethusQuerys'
UPDATE rethus.tblRethusQuerys
SET
    iIDQueryState = 7
GO

UPDATE rethus.tblRethusTasks
SET
    iIDTaskState = 3
GO