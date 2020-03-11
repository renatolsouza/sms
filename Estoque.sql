SET @CODEMPRESA = 1;
SET @CODDEPARTAMENTO = 3; 
SET @MES = 3;
SET @ANO = 2020;

SELECT E.ID, E.CODEMPRESA, EMP.NOME AS NOMEEMPRESA, E.CODDEPARTAMENTO, D.NOME AS NOMEDEPARTAMENTO, E.MES, E.ANO, 
E.CODPRODUTO, P.NOME AS NOMEPRODUTO, E.QTANTERIOR, E.ENTRADA, E.SAIDA, E.QTATUAL
FROM estoque E
INNER JOIN empresa EMP ON E.CODEMPRESA = EMP.CODEMPRESA
INNER JOIN departamento D ON E.CODDEPARTAMENTO = D.CODDEPARTAMENTO
INNER JOIN produtos P ON P.CODPRODUTO = E.CODPRODUTO

WHERE E.CODEMPRESA = @CODEMPRESA
AND E.CODDEPARTAMENTO = @CODDEPARTAMENTO
AND E.MES = @MES
AND E.ANO = @ANO
ORDER BY P.NOME