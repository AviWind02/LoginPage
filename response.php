<?php
include ('connection.php');
// LOGIN USER
if (isset($_POST['login_user'])) {
  $username = mysqli_real_escape_string($conn, $_POST['username']);
  $password = mysqli_real_escape_string($conn, $_POST['password']);


  if (empty($username)) {
    echo 'Error, Username is required';
  	return;
  }
  if (empty($password)) {
    echo 'Error, Password is required.';
  	  	return;
  }

  if (count($errors) == 0) {
  	$password = md5($password);
  	$query = "SELECT * FROM users WHERE username='$username' AND password='$password'";
  	$results = mysqli_query($conn, $query);
  	
  	if (mysqli_num_rows($results) == 1) {
    echo"true";
  	}else {
        echo 'Error, Wrong username/password combination.';
  	}
  }
   $conn->close(); 
}


?>