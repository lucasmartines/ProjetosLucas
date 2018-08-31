/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


$(document).ready 
(
        
        function(){
            
            setInterval(function()
            {
                 $.ajax({
                    url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action=show",
                    success:function(data){
                        $("#showData").text("");
                        $("#showData").append(data);
                    }
                });
            },1000);
            $("#pop").click(function(){
                
                $.ajax({
                    url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action=pop",
                    success:function(data){
                        $("#showData").text("");
                        $("#showData").append(data);

                    }
                });
            });
            $("#delete").click(function(){
                
                $.ajax({
                    url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action=delete&deleteNumber="+ $("#delete_number").val(),
                    success:function(data){
                        $("#showData").text("");
                        $("#showData").append(data);
                        $("#deleteNumber").val(" ");
                        $("#deleteNumber").text(" ");
                    }
                });
            });
            $("#destroy").click(
                function()
                {
                    
                    $.ajax(
                    {   
                        url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action=reset",
                        contentType:"application/x-www-form-urlencoded",
                        success:function(data){
                            $("#showData").text("");
                            $("#showData").text(data);
                            
                        }
                        
                    });
                }
            );
            $("#show").click(
            function(){
                
                $.ajax({
                    url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action=show",
                    success:function(data){
                        $("#showData").text("");
                        $("#showData").append(data);
                    }
                });
            });
            
            $("#insert").click(
                function()
                {
                    
                    $.ajax(
                    {   
                        url:"http://localhost/ProjetosLucas/PHP_Estudos/PHP_IDE/ProjetoHelloWord/index.php?action="
                        +$("#insert").val()
                        +"&nome="+$("#nome").val()
                        +"&descricao="+$("#descricao").val(),
                        success:function(data){
                            
                            $("#showData").text("");
                            $("#showData").append(data);
                            //console.log(data);
                        }
                        
                    });
                }
            );
            
           
            
            
        }

);