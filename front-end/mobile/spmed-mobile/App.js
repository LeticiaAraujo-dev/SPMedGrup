import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import consulta from './src/screens/consulta';
import login from './src/screens/login';

const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator
        headerMode = 'none'
      >
        <AuthStack.Screen name = 'Login' component={login} />
        <AuthStack.Screen name = 'Consulta' component={consulta} />
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}