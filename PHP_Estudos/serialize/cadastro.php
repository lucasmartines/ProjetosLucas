<?php
    require 'connection.php';


    if ( $_SERVER['REQUEST_METHOD'] === 'POST')
    {
        if ( isset( $_POST['name'] ) && isset( $_POST['password'] )  )
        {
            $name = $_POST['name'];
            $senha = $_POST['password'];
            
            $sql = "select NOME from usuario where NOME = '$name' ";
            $query = mysqli_query( $con , $sql );
           
            if ( mysqli_num_rows ($query) > 0 )
            {
                echo "já existe alguem com este nome volte : <a href = 'cadastro.php'> cadastro </a>";
            }
            else
            {
                $senha = sha1($senha);
                $sql2 = "INSERT INTO usuario ( NOME , SENHA ) VALUES ( '$name' , '$senha' )";
                
                if( mysqli_query( $con , $sql2 ) ){
                    header("Location:cadastrado.php?test=$name");
                }
                else{
                    echo mysqli_error($con);
                }
               
            }

        }
        
    }
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style>
        body{
            width:800px;
            background-color:#f1f1f1;
            margin:auto;
        }
        form{
           
            width:200px;
            background-color:#aaa;
            color:white;

            margin:auto;
            margin-top: 200px;
            padding:20px;
            border-radius: 20px;
        }
        input[type=submit]{
            padding:10px;
            
            margin:auto;
        }
    </style>
</head>
<body>

    <form action=" <?php echo htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
    <h1 style="text-align:center"> Cadastro </h1>
        <p> User </p>
        <input type="text" name = "name"  />
        <p> Password </p>
        <input type="password" name = "password"  />
        </br>
        </br>
        <input type="submit" value = "Signup" />
    </form>

</body>
</html>