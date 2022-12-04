<?php


        $db = new PDO('mysql:host=localhost;dbname=dbname;charset=utf8','users','pass');

        function generateRandomString($length = 10) 
        {

            return substr(str_shuffle(str_repeat($x='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ', ceil($length/strlen($x)) )),1,$length);

        }
        
    $i = $_POST['i'];


    if($i == "create")
    {
    			$user = $_POST["user"];
                $sure = date("d-m-Y H:i:s");
                $olusankod = generateRandomString(10);



                $query = $db->query("SELECT * FROM appkeys WHERE code = '{$olusankod}' ")->fetch(PDO::FETCH_ASSOC);

                if($query != null)

                {

                    while($query != null)

                    {

                        $olusankod = generateRandomString(10);

                        $query = $db->query("SELECT * FROM appkeys WHERE code = '{$olusankod}' ")->fetch(PDO::FETCH_ASSOC);

                    }



                    $db->exec("INSERT INTO appkeys (code,clue) VALUES ('{$olusankod}','{$sure}')");   




                  

                }

                else

                {

                    $db->exec("INSERT INTO appkeys (code,clue) VALUES ('{$olusankod}','{$sure}')");   


                }
            
                	$query = $db->query("SELECT * FROM users WHERE email = '{$user}' ")->fetch(PDO::FETCH_ASSOC);

                	$keyleri = $query["created_keys"];

                	if($keyleri != null)
                		$keyleri = $keyleri."&".$olusankod.",".$sure;
                	else
                		$keyleri = $keyleri.$olusankod.",".$sure;

            		echo $olusankod;


                    $query = $db->prepare("UPDATE users SET created_keys = :keylers WHERE email = :email");
                    $update = $query->execute(array("keylers" => $keyleri,"email" => $user));

					



 
    }
    
    
    else if($i=="login")
    {
        $mail = $_POST["mail"];
        $pass = $_POST["pass"];
        
        $email_validation_regex = '/^\\S+@\\S+\\.\\S+$/'; 
        if(preg_match($email_validation_regex, $mail) == true)
        {
            $query = $db->query("SELECT * FROM users WHERE email = '{$mail}'")->fetch(PDO::FETCH_ASSOC);

            if($query != null)
            {
                if($query["pass"] == trim($pass))
                    echo "Giriş Başarılı";
                else 
                    echo "Şifre Yanlış";
            }
            
            else
            {
                echo "Mail Adresi Bulunamadı";
            }
        }
        
        else
        {
            echo "Giriş Biçiminiz Doğru Değil";    
        }// returns 1
              
     
    }




    else if($i=="mycodes")
    {
        $mail = $_POST["user"];
                
           $query = $db->query("SELECT * FROM users WHERE email = '{$mail}'")->fetch(PDO::FETCH_ASSOC);

            if($query != null)
            {
               echo $query["created_keys"];
            }
            
           
   
    }


    else if($i == "singup")
    {

		$mail = $_POST["user"];
		$pass = $_POST["pass"];

    	$query = $db->query("SELECT * FROM users WHERE email = '{$mail}'")->fetch(PDO::FETCH_ASSOC);

    	if($query == null)
    	{
    		$db->exec("INSERT INTO users (email,pass) VALUES ('{$mail}','{$pass}')");   
    		echo "Hesabınız Oluşturuldu";
    	}
    	else
    	{
    		echo "Bu Eposta Sisteme Kayıtlı!";
    	}
    }

?>