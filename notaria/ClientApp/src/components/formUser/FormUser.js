import React, { useState, useEffect } from "react";
import axios from 'axios';
import styles from "./FormUser.module.scss";
import Input from "../input/Input";
import Button from "../../components/button/Button";
import editBlackIcon from "../../icons/editBlackIcon.png";

export default function FormUser({ formType, modifyUser }) {
    const [data, setData] = useState({ nombre: '', apellido: '', correo: '', clave: '', modificar: false });
    const [campos, setCampo] = useState({ nombre: null, apellido: null, correo: null, clave: null, clave2: null, modificar: false });
    const [activated, setActivated] = useState({ nombre: true, apellido: true, correo: true, clave: true, clave2: true });

    //Validacion de Formulario
    const expresiones = {
        nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
        password: /^.{4,12}$/, // 4 a 12 digitos.
        correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    }

    const onChange = (e) => {
        e.persist();
        switch (e.target.name) {
            case "nombre":
                if (expresiones.nombre.test(e.target.value)) {
                    setCampo({ ...campos, nombre: true });
                } else {
                    setCampo({ ...campos, nombre: false });
                }
                break;
            case "apellido":
                if (expresiones.nombre.test(e.target.value)) {
                    setCampo({ ...campos, apellido: true });
                }
                else {
                    setCampo({ ...campos, apellido: false });
                }
                break;
            case "correo":
                if (expresiones.correo.test(e.target.value)) {
                    setCampo({ ...campos, correo: true });
                }
                else {
                    setCampo({ ...campos, correo: false });
                }
                break;
            case "clave":
                if (expresiones.password.test(e.target.value)) {
                    setCampo({ ...campos, clave: true });
                }
                else {
                    setCampo({ ...campos, clave: false });
                }
                break;
            case "clave2":
                const inputPassword1 = document.getElementById('clave');
                if (inputPassword1.value !== e.target.value) {
                    setCampo({ ...campos, clave2: false });
                } else {
                    setCampo({ ...campos, clave2: true });
                }
                break;
            case "modificar":
                const modificar = document.getElementById('modificar');

                if (modificar.checked) {
                    setCampo({ ...campos, modificar: true });
                } else {
                    setCampo({ ...campos, modificar: false });
                }
                break;
        }
        setData({ ...data, [e.target.name]: e.target.value });
    }

    //Creación de Usuario
    const URL = "https://localhost:7028/api/Usuario/CrearUser";
    const createUSer = (e) => {
        e.preventDefault();

        if (formType === '0') {
            //console.log(campos)
            if (data.nombre !== '' && data.apellido !== '' && data.correo !== '' && data.clave !== '') {
                if (campos.nombre && campos.apellido && campos.correo && campos.clave) {
                    const dataUser = { nombre: data.nombre, apellido: data.apellido, correo: data.correo, clave: data.clave, modificar: data.modificar };
                    axios.post(URL, dataUser)
                        .then((result) => {
                            console.log(result);
                            e.target.reset();
                            alert('usuario Creado');
                            /*if (result.data.Status == 'Invalid')
                                alert('Invalid User');
                            else
                                props.history.push('/Dashboard')*/
                        })
                    //console.log(dataUser)
                    /*if (dataUser.nombre !== '' && dataUser.apellido !== '' && dataUser.correo !== '' && dataUser.clave !== '' && dataUser.modificar !== '') {
                        console.log("Datos Completos");
                    }
                    else {
                        console.log("Inputs Vacios");
                    }
                    //formularioCreacion.reset();
                    console.log("se envio el formulario");
                    //document.getElementById('formulario__mensaje-exito').classList.add('formulario__mensaje-exito-activo');
                    /*setTimeout(() => {
                        document.getElementById('formulario__mensaje-exito').classList.remove('formulario__mensaje-exito-activo');
                    }, 5000);
        
                    document.querySelectorAll('.formulario__grupo-correcto').forEach((icono) => {
                        icono.classList.remove('formulario__grupo-correcto');
                    });*/
                } else {
                    //document.getElementById('formulario__mensaje').classList.add('formulario__mensaje-activo');
                    console.log("no se envio el formulario");
                }
            } else {
                console.log("inputs vacios")
            }
        /*const dataUser = { nombre: data.nombre, apellido: data.apellido, correo: data.correo, clave: data.clave, modificar: data.modificar };
            console.log(dataUser);
            if (dataUser.nombre !== '' && dataUser.apellido !== '' && dataUser.correo !== '' && dataUser.clave !== '' && dataUser.modificar !== '') {
                console.log("Datos Completos");
            }
            else {
                console.log("Inputs Vacios");
            }
            /*axios.post(URL, dataUser)
                .then((result) => {
                    console.log(result);
                    if (result.data.Status == 'Invalid')
                        alert('Invalid User');
                    else
                        props.history.push('/Dashboard')
                })*/
        } else {
            console.log("formulario Modificacion");
            const userData = document.getElementsByTagName('input');
            console.log(userData)
            Array.from(userData).map(value => {
                switch (value.id) {
                    case "nombre":
                        console.log(value.value)
                        break;
                    case "apellido":
                        console.log(value.value)
                        break;
                    case "correo":
                        console.log(value.value)
                        break;
                    case "clave":
                        console.log(value.value)
                        break;
                }
            })
        }
    }

    console.log(data);

    const handleDesactivated = (e) => {
        e.preventDefault();
        switch (e.target.id) {
            case "nombre":
                if (activated.nombre) {
                    setActivated({ ...activated, nombre: false });
                }
                break;
            case "apellido":
                if (activated.apellido) {
                    setActivated({ ...activated, apellido: false });
                }
                break;
            case "correo":
                if (activated.correo) {
                    setActivated({ ...activated, correo: false });
                }
                break;
            case "clave":
                if (activated.clave) {
                    setActivated({ ...activated, clave: false });
                }
                break;
            case "clave2":
                if (activated.clave2) {
                    setActivated({ ...activated, clave2: false });
                }
                break;
        }
    };

    const handleActivated = () => {
        if (!activated) {
            setActivated(true);
        }
    };

    if (formType !== '0') {
        return (
            <>
                <h3>Formulario Modificar</h3>
                <form onSubmit={createUSer}>
                    <div className={styles.rowOneContainer}>
                        <div className={styles.inputNombre}>
                            <Input
                                label="Nombre"
                                disabled={activated.nombre}
                                inputOverLabel
                                icon={editBlackIcon}
                                id="nombre"
                                name="nombre"
                                onChange={onChange}
                                placeholder="Nombre"
                                type="text"
                                variant="inputCreateUser"
                                validate={campos.nombre}
                                onClick={handleDesactivated}
                                value={modifyUser.nombre}
                            />
                        </div>
                        <div className={styles.inputApellido}>
                            <Input
                                label="Apellido"
                                disabled={activated.apellido}
                                inputOverLabel
                                icon={editBlackIcon}
                                id="apellido"
                                name="apellido"
                                onChange={onChange}
                                placeholder="Apellido"
                                type="text"
                                variant="inputCreateUser"
                                validate={campos.apellido}
                                onClick={handleDesactivated}
                                value={modifyUser.apellido}
                            />
                        </div>
                    </div>
                    <div className={styles.rowTwoContainer}>
                        <div className={styles.inputApellido}>
                            <Input
                                label="Correo"
                                disabled={activated.correo}
                                inputOverLabel
                                icon={editBlackIcon}
                                id="correo"
                                name="correo"
                                onChange={onChange}
                                placeholder="Correo"
                                type="email"
                                variant="inputCreateUser"
                                validate={campos.correo}
                                onClick={handleDesactivated}
                                value={modifyUser.correo}
                            />
                        </div>
                    </div>
                    <div className={styles.rowThreeContainer}>
                        <div className={styles.inputContraseña}>
                            <Input
                                label="Contraseña"
                                disabled={activated.clave}
                                inputOverLabel
                                icon={editBlackIcon}
                                id="clave"
                                name="clave"
                                onChange={onChange}
                                placeholder="********"
                                type="password"
                                variant="inputCreateUser"
                                validate={campos.clave}
                                onClick={handleDesactivated}
                                value={modifyUser.clave}
                            />
                        </div>
                        <div className={styles.inputConfirmarContraseña}>
                            <Input
                                label="Confirmar Contraseña"
                                disabled={activated.clave2}
                                inputOverLabel
                                icon={editBlackIcon}
                                id="clave2"
                                name="clave2"
                                placeholder="********"
                                onChange={onChange}
                                type="password"
                                variant="inputCreateUser"
                                validate={campos.clave2}
                                onClick={handleDesactivated}
                                value={modifyUser.clave}
                            />
                        </div>
                    </div>
                    <div className={styles.inputCheckboxContainer}>
                        <Input
                            id="modificar"
                            name="modificar"
                            onChange={onChange}
                            type="checkbox"
                            label="Modificar vencidos"
                            labelRight
                            variant="inputCheckboxBackground"
                            labelWithBackground
                            value={modifyUser.modificar}
                        />
                    </div>
                    <div className={styles.buttonContainer}>
                        <Button
                            variant="saveUser"
                            text="Guardar cambios"
                            type="submit"
                        />
                    </div>
                </form>
            </> 
        );
    }

    return (
        <>
            <form onSubmit={createUSer}>
                <div className={styles.rowOneContainer}>
                    <div className={styles.inputNombre}>
                        <Input
                            label="Nombre"
                            disabled={activated}
                            inputOverLabel
                            id="nombre"
                            name="nombre"
                            onChange={onChange}
                            placeholder="Nombre"
                            type="text"
                            variant="inputCreateUser"
                            validate={campos.nombre}
                        />
                    </div>
                    <div className={styles.inputApellido}>
                        <Input
                            label="Apellido"
                            disabled={activated}
                            inputOverLabel
                            id="apellido"
                            name="apellido"
                            onChange={onChange}
                            placeholder="Apellido"
                            type="text"
                            variant="inputCreateUser"
                            validate={campos.apellido}
                        />
                    </div>
                </div>
                <div className={styles.rowTwoContainer}>
                    <div className={styles.inputApellido}>
                        <Input
                            label="Correo"
                            disabled={activated}
                            inputOverLabel
                            id="correo"
                            name="correo"
                            onChange={onChange}
                            placeholder="Correo"
                            type="email"
                            variant="inputCreateUser"
                            validate={campos.correo}
                        />
                    </div>
                </div>
                <div className={styles.rowThreeContainer}>
                    <div className={styles.inputContraseña}>
                        <Input
                            label="Contraseña"
                            disabled={activated}
                            inputOverLabel
                            id="clave"
                            name="clave"
                            onChange={onChange}
                            placeholder="********"
                            type="password"
                            variant="inputCreateUser"
                            validate={campos.clave}
                        />
                    </div>
                    <div className={styles.inputConfirmarContraseña}>
                        <Input
                            label="Confirmar Contraseña"
                            disabled={activated}
                            inputOverLabel
                            id="clave2"
                            name="clave2"
                            placeholder="********"
                            onChange={onChange}
                            type="password"
                            variant="inputCreateUser"
                            validate={campos.clave2}
                        />
                    </div>
                </div>
                <div className={styles.inputCheckboxContainer}>
                    <Input
                        id="modificar"
                        name="modificar"
                        onChange={onChange}
                        type="checkbox"
                        label="Modificar vencidos"
                        labelRight
                        variant="inputCheckboxBackground"
                        labelWithBackground
                    />
                </div>
                <div className={styles.buttonContainer}>
                    <Button
                        variant="saveUser"
                        text="Guardar cambios"
                        type="submit"
                    />
                </div>
            </form>
        </>
    );
}
