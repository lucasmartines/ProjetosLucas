<?php 
    

    if( !isset( $_COOKIE['nome'] )  && !isset($_GET['nome'])  )
    {
        echo '<br>unset set';    
        
?>
    <!doctype html>
    <html>
            <head>
                <title>Login</title>
                <meta name='viewport' content='width=device-width,initial-scale=1'/>
                <style>
                    form{
                        width:200px;
                        height:200px;
                        margin: 3% auto;
                    }
                    input {
                        width:100%;
                    }
                </style>
            </head>
            <body>
                
                <form action="estudo-file.php" method="get">
                    <p> Usuario </p>
                    <input type="text" name="nome"/>
                    <input type="submit" name="Submeter" />
                </form>

            </body>
        </html>

<?php    
    } #close if isset cookie nome
    
     else if( isset($_GET['nome'])  )// if( isset( $_COOKIE['nome'] ) || isset($_GET['nome']) )
        {
            setcookie ('nome' , $_GET['nome'] , time() + 60 * 10);
       echo '<br>cookie set';     
?>
<!doctype html>
<html>
    <head>
        <title>title</title>
        <meta name='viewport' content='width=device-width,initial-scale=1'/>
        <style>

            *{
                box-sizing:border-box;
                margin:0;
                padding:0;
            }
            .container{
                width:80%;
                height:100%;
                background-color:#ddd;
                margin: 0 auto;
            }
            #showData{
                border: 1px solid #333;
                width:60%;
                height:50%;
                overflow:auto;
                  scroll-behavior: smooth;
                 
            }

            
            input[type='text']{
                width:80%;
                
            }

            .message{
                margin-top:10px;
                
            }
            @media (max-width:600px){
                #showData{
                    width:100%;
                    height:60%;
                }
                input[type='submit'],input[type='text']{
                   height:30px;
                    width:100%;
                    
                }
                .container{
                width:100%;
                padding:3px;
                background-color:#ddd;
                margin: 0 auto;
            }
            }
        </style>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"> </script>

    </head>
    <body>
            <div class="container">
 
                <h2> <?php if ( isset ( $_COOKIE['nome'] ) ) { echo "User: ".$_COOKIE['nome']; } else { echo "user: ".$_GET['nome'];}  ?> </h2>

                <div id="showData"></div><br>
                <input id="userinput" name="input" type="text" value=""><br>
                <input id="submit" type="submit" value="submit"><br>
            
                <form action="file-operator.php?">
                    
                <input  type='submit' id="logoff" name='action' value='destroy_session'>
                </form>           
            </div>


        <script> 
            
            $(document).ready(function(){
                setInterval(function(){
                    $.get(
                        {
                            url:'file-operator.php?action=get_data',
                            contentType:"text/html"
                        },
                        function(data){
                            $("#showData").html(data);
                         
                        }
                    );
                },500);
              
                
                $("#submit").click( function() {
                    
                    submit();
                    
                });
                $("#userinput").keypress(function(e){
                    if(e.keyCode == 13){
                        submit();
                    }
                });
                
            
            });

            function submit(){
                var userInput = $("#userinput").val();
                    //console.log(userInput);
                    $.get
                    ({
                        //url:'file-operator.php?user_input='+userInput,
                      url:'file-operator.php?action=put_data&user_input='+userInput,
                      contentType:"text/html"
                        
                    },function(data){
                        $("#userinput").val("");
                        $('#showData').html(data);
                         console.log( $("#showData").css('height') );
                         
                    });
            }
        </script>
    </body>
    
</html>

<?php  
    }
?>