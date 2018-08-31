<?php 

include_once 'load.php';

$p = new pessoa();
$p->nome = "Lucas";
$output = sprintf( "Olá %s ",$p->nome);
print($output);
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style>
        body {
            background-color:orange;
        }
    </style>
</head>
<body>
    
</body>
</html>