import React, { useState, useEffect } from "react";
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from "../button/Button";
import Input from "../input/Input";
import logo from "../../images/logo.png";
import imageSide from "../../images/imgLogin.png";
import styles from "./Login.module.scss";

export default function Login(props) {
    const [user, setUser] = useState({ Correo: '', Clave: '' });
    const [email, setEmail] = useState( {Correo: '', validate: true} );
    const [password, setPassword] = useState( {Clave: '', validate: true} );
    let navigate = useNavigate();
  
    const URL = "https://localhost:7028/api/Usuario";
    const Login = (e) => {
        e.preventDefault();
        const data = { Correo: email.Correo, Clave: password.Clave }

        //console.log(data)
        if (email.Correo !== '' && password.Clave !== '') {
            axios.post(URL, data)
                .then((response) => {
                    //const serializedState = JSON.stringify(result.data);
                    //console.log(serializedState)
                    console.log(response)
                    //var a = localStorage.setItem('myData', serializedState);
                    //console.log("A: ", a)
                    //const user = result.data.userDetails;
                    if (response.status === 200)
                        navigate('/inicio')
            }).catch(function (error) {
                console.log(error.response);
            }) 
        } else {
            if (email.Correo === '') {
                setEmail({ Correo: '', validate: false });
                
            }
            if (password.Clave === '') {
                setPassword({ Clave: '', validate: false });
            }
        }
    }

    const onChangeCorreo = (e) => {
        e.persist();
        if (document.getElementById("Correo") !== '') {
            setEmail({ ...email, Correo: e.target.value, validate: true });
        }
    }

    const onChangePassword = (e) => {
        e.persist();
        if (document.getElementById("Clave") !== '') {
            setPassword({ ...password, Clave: e.target.value, validate: true });
        }
    }

    return (
        <div className={styles.loginContainer}>
            <div className={styles.imageContainer}>
                <img className={styles.sideImage} src={imageSide} alt="imagen login" />
            </div>
            <div className={styles.formContainer}>
                <div className={styles.contentContainer}>
                    <div className={styles.logoContainer}>
                        <img className={styles.logo} src={logo} alt="Logo" />
                    </div>
                    <div className={styles.form}>
                        <form onSubmit={Login}>
                            <div className={styles.inputContainer}>
                                <Input
                                    id="Correo"
                                    name="Correo"
                                    type="email"
                                    placeholder="example@example.com"
                                    label="Correo"
                                    onChange={onChangeCorreo}
                                    variant="inputLogin"
                                    validate={email.validate}
                                />
                            </div>
                            <div className={styles.inputContainer}>
                                <Input
                                    id="Clave"
                                    name="Clave"
                                    type="password"
                                    placeholder="***********"
                                    label="Contraseña"
                                    onChange={onChangePassword}
                                    variant="inputLogin"
                                    validate={password.validate}
                                />
                            </div>
                            <div className={styles.forgetPassword}>
                                <a href="/">¿Olvidaste tu contraseña?</a>
                            </div>
                            <div className={styles.inputContainerCheckBox}>
                                <Input
                                    type="checkbox"
                                    label="Recordar contraseña"
                                    labelRight
                                    variant="inputCheckbox"
                                />
                            </div>
                            <div className={styles.buttonContainer}>
                                <Button
                                    variant="loginButton"
                                    text="Iniciar sesión"
                                    type="submit"
                                />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
