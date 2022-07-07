import React, { useState } from "react";
import axios from "axios";
import { useSelector } from "react-redux";
import TitleHeader from "../components/title/TitleHeader";
import TopBar from "../components/topbar/TopBar";
import SideBar from "../components/sidebar/SideBar";
import Input from "../components/input/Input";
import Button from "../components/button/Button";
import editBlackIcon from "../icons/editBlackIcon.png";
import styles from "../scss/pages/Configuracion.module.scss";

export default function Configuracion() {
    const [activated, setActivated] = useState(false);
    const [data, setData] = useState({ nombre: '', apellido: '', correo: '', clave: '', modificar: false });

    const URL = "https://localhost:7028/api/Usuario/CrearUser";

    const createUSer = (e) => {
        e.preventDefault();
        const dataUser = { nombre: data.nombre, apellido: data.apellido, correo: data.correo, clave: data.clave, modificar: data.modificar };
        axios.post(URL, dataUser)
            .then((result) => {
                console.log(result);
                /*if (result.data.Status == 'Invalid')
                    alert('Invalid User');
                else
                    props.history.push('/Dashboard')*/
            })
    }

    const onChange = (e) => {
        e.persist();
        setData({ ...data, [e.target.name]: e.target.value });
    } 

    console.log(data)

    const handleDesactivated = () => {
        if (activated) {
            setActivated(false);
        }
    };

    const handleActivated = () => {
        if (!activated) {
            setActivated(true);
        }
    };

    const handleClick = () => {
        console.log("Guardado");
    };

    const state = useSelector((state) => state);

    return (
        <div className={styles.configuracionContainer}>
            <div
                className={
                    state.stateMenu
                        ? styles.sideBarContainer
                        : `${styles.sideBarContainer} ${styles.sideBarClose}`
                }
            >
                <SideBar />
            </div>
            <div
                className={
                    state.stateMenu
                        ? styles.contentContainer
                        : `${styles.contentContainer} ${styles.contentContainerClose}`
                }
            >
                <div
                    className={
                        state.stateMenu
                            ? styles.topBarContentContainer
                            : `${styles.topBarContentContainer} ${styles.topBarContentContainerClose}`
                    }
                >
                    <div className={styles.topBarContainer}>
                        <TopBar />
                    </div>
                    <div className={styles.titleContainer}>
                        <TitleHeader text="Usuario" withoutIcon />
                    </div>
                    <div className={styles.formContainer}>
                        <form onSubmit={createUSer}>
                            <div className={styles.rowOneContainer}>
                                <div className={styles.inputNombre}>
                                    <Input
                                        label="Nombre"
                                        disabled={activated}
                                        inputOverLabel
                                        icon={editBlackIcon}
                                        id="nombre"
                                        name="nombre"
                                        onChange={onChange}
                                        placeholder="Nombre"
                                        type="text"
                                        variant="inputCreateUser"
                                        onClick={handleDesactivated}
                                    />
                                </div>
                                <div className={styles.inputApellido}>
                                    <Input
                                        label="Apellido"
                                        disabled={activated}
                                        inputOverLabel
                                        icon={editBlackIcon}
                                        id="apellido"
                                        name="apellido"
                                        onChange={onChange}
                                        placeholder="Apellido"
                                        type="text"
                                        variant="inputCreateUser"
                                        onClick={handleDesactivated}
                                    />
                                </div>
                            </div>
                            <div className={styles.rowTwoContainer}>
                                <div className={styles.inputApellido}>
                                    <Input
                                        label="Correo"
                                        disabled={activated}
                                        inputOverLabel
                                        icon={editBlackIcon}
                                        id="correo"
                                        name="correo"
                                        onChange={onChange}
                                        placeholder="Correo"
                                        type="email"
                                        variant="inputCreateUser"
                                        onClick={handleDesactivated}
                                    />
                                </div>
                            </div>
                            <div className={styles.rowThreeContainer}>
                                <div className={styles.inputContraseña}>
                                    <Input
                                        label="Contraseña"
                                        disabled={activated}
                                        inputOverLabel
                                        icon={editBlackIcon}
                                        id="clave"
                                        name="clave"
                                        onChange={onChange}
                                        placeholder="********"
                                        type="password"
                                        variant="inputCreateUser"
                                        onClick={handleDesactivated}
                                    />
                                </div>
                                <div className={styles.inputConfirmarContraseña}>
                                    <Input
                                        label="Confirmar Contraseña"
                                        disabled={activated}
                                        inputOverLabel
                                        icon={editBlackIcon}
                                        placeholder="********"
                                        type="password"
                                        variant="inputCreateUser"
                                        onClick={handleDesactivated}
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
                                    //onClick={handleClick}
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
