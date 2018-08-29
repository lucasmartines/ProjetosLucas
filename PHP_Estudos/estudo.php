<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style>
        tr,th , td{
            border: solid 1px black;
        }
    </style>
</head>
<body>
    
    <?php 

    $host = 'localhost';
    $user = 'root';
    $password ='';
    $dbname = 'pdoposts';

    // DSN data source name

    $dsn = 'mysql:host='.$host.';dbname='.$dbname;
    // connection

    $pdo = new PDO($dsn,$user,$password);
    $pdo->setAttribute( PDO::ATTR_DEFAULT_FETCH_MODE,PDO::FETCH_OBJ);

    // PDO METHOD THAT USES QUERY
        /* 
    $stmt = $pdo->query("SELECT * FROM posts");
    // show data
 /*
    while ( $row = $stmt->fetch(PDO::FETCH_ASSOC))
    {
        echo $row['body'].'<br>';
    }
  while ( $row = $stmt->fetch(PDO::FETCH_ASSOC) )
    {
        echo $row['author'].'<br>';
    }
    
    */
    # PREPARED STATEMENTS (prepare & execute)

    // UNSAFE
    //$sql = "SELECT * FROM posts WHERE author = '$author'"
    // user input
/*
   $sql = 'SELECT * FROM posts WHERE author = ?';
    $stmt = $pdo->prepare($sql);
    $stmt->execute([$author]);
    $posts = $stmt->fetchAll();
*/
    $author = 'Gene Roddenberry';
    $is_published = true;
    // FETCH MULTIPLE POSTS
    // Positional Params
    $sql = 'SELECT * FROM posts WHERE author = :author && is_published = :is_published';

    $stmt = $pdo->prepare($sql);
    $stmt->execute( ['author' => $author,'is_published'=>$is_published]);
    $posts = $stmt->fetchAll();
    // var_dump($posts);
    foreach ($posts as $post){
        echo $post->title.'<br>';
    }
    ?>
</body>
</html>

