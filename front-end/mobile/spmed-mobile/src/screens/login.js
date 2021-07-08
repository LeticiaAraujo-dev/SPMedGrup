import React, { Component } from 'react';
import { Image, ImageBackground, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

    realizarLogin = async () => {
        console.warn( this.state.email + ' ' + this.state.senha );

        const resposta = await api.post('/Usuarios/Login', {
            email : this.state.email,
            senha : this.state.senha
        });

        const token = resposta.data.token;
        console.warn(token);

        await AsyncStorage.setItem('userToken', token);

        this.props.navigation.navigate('Consulta');
    };

    render(){
        return (
            <ImageBackground 
            style={StyleSheet.absoluteFillObject}
            style= {styles.main}
            >
                <TextInput style={styles.inputLogin}
                    placeholder='username'
                    placeholderTextColor='#167866'
                    keyboardType='email-address'
                    onChangeText={email => this.setState({ email })}
                />

                <TextInput style={styles.inputLogin}
                    placeholder='password'
                    placeholderTextColor='#167866'
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({ senha })}
                />

                <TouchableOpacity
                    style={styles.btnLogin}
                    onPress={this.realizarLogin}
                >
                </TouchableOpacity>

            </ImageBackground>
        );
    }

}

const styles = StyleSheet.create({

    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: 'rgba(183, 39, 255, 0.79)'
    },

    main: {
        width: '100%',
        height: '100%',
        justifyContent: 'center',
        backgroundColor: '#F1F1F1' ,
        alignItems: 'center'
    },

    mainImgLogin: {
        backgroundColor: '#000' ,
        height: 100,
        width: 90,
        margin: 60,
        marginTop: 0
    },
    
    inputLogin: {
        marginTop: 50,
        width: 240,
        marginBottom: 40,
        fontSize: 18,
        color: '#167866',
        borderColor: '#167866',
        borderBottomWidth: 2
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 240,
        backgroundColor: '#167866',
        borderColor: '#167866',
        borderWidth: 1,
        borderRadius: 4,
        shadowOffset: { height: 1, width: 1 }
    },

    btnLoginText: {
        fontSize: 12,
        fontFamily: 'Open Sans Light',
        color: '#167866',
        letterSpacing: 6,
        textTransform: 'uppercase'
    }

});