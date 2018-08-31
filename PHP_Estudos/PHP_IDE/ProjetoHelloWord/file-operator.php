<?php
date_default_timezone_set( 'America/Sao_Paulo' );
#PLAYER WANT LOGIN
if ( !isset( $_COOKIE['nome'] ) )
{
    
    header("Location:estudo-file.php");
}
if(isset( $_GET['action']) ) 
    {
    
    #PLAYER SENT DATA TO SERVER
    if($_GET['action'] == 'put_data'){
        if( isset( $_GET['user_input'] ) ){

            if( $_GET['user_input'] != ' ')
            {   
                    # IF THE TIME OF PLAYER LOGIN END
                  if( !isset( $_COOKIE['nome'] ) ){
                      header('Local: estudo-file.php');
                  }
                  # GET URL USER INPUT
                $ui = $_GET['user_input'] ;
                
                  #OPEN FILE IO
                $file = fopen('io.txt','a') or die("erro não foi possivel abrir arquivo");
                # WRITE A MESSAGE IM THIS FILE
                fwrite( $file ,'<div class="message">' . ' <p> '.' <span style="color:blue"> N: ' . $_COOKIE['nome'] .'</span> Message: '. $ui . '</p>' . '<p style="font-size:8px;"> Horario:' .date('l jS \of F Y h:i:s A') . '</p>' . '</div>'.PHP_EOL);
                # CLOSE FILE
                fclose($file);
                #OUTPUT DATA
                showData();
                  
               
            }

        }

    }#PLAYER WHANT DATA FROM SERVER
    else if($_GET['action'] == 'get_data'){
        
     
        showData();
    }
    else if($_GET['action'] == 'destroy_session'){
        /*destroy cookie*/
        setcookie('nome','',time() - 60*10);
        header('Location: estudo-file.php');
    }
    
    
}
function showData(){
    $file = fopen('io.txt','r') or die("erro não foi possivel abrir arquivo");
    $arr = [];
    $ind = 0;
    while( !feof($file) )
    {
         //echo "<p>"  .  fgets($file)  . "</p>";
         array_push( $arr , "<p>"  .  fgets($file)  . "</p>" );
       //  $arr[$ind] =    fgets($file) ;
         $ind++;
    }
    
    
    fclose($file);
    #CORRER ARRAY AO CONTRARIO RUM ARRAY OPPOSITE DIRECITION FROM LAST TO START
   
    for( $conter = $ind - 1; $conter >= 0; $conter--){
       if(  isset($arr[$conter]) ) {
            echo $arr[$conter] ;
       }
    }
}