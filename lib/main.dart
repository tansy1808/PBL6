import 'package:flutter/material.dart';
import 'package:pbl6/screens/login_screen/cart_screen.dart';
import 'package:pbl6/screens/login_screen/home_screen.dart';
import 'package:pbl6/screens/login_screen/item_screen.dart';
import 'package:pbl6/utils/constants.dart';

import 'screens/login_screen/login_screen.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {


  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Login App',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        scaffoldBackgroundColor: kBackgroundColor,
        textTheme: Theme.of(context).textTheme.apply(
          bodyColor: kPrimaryColor,
          fontFamily: 'Montserrat',
        ),
      ),
      routes: {
        "/" : (context) => LoginScreen(),
        "homeScreen" : (context) => HomeScreen(),
        "cartScreen" :(context) => CartScreen(),
        "itemScreen" :(context) => ItemScreen(),
      },
      //home: LoginScreen(),
    );
  }
}

