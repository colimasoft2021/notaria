import React, { useState, useEffect } from "react";
import axios from "axios";
import Cookies from "universal-cookie";
import { useSelector } from "react-redux";
import { useNavigate, Link } from "react-router-dom";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import styles from "../scss/pages/CatalogoResponsables.module.scss";
import Button from "../components/button/Button";
import editIcon from "../icons/editIcon.png";
import deleteIcon from "../icons/deleteIcon.png";

export default function CatalogoResponsables() {
    const state = useSelector((state) => state);
    let navigate = useNavigate();
    const [users, setUsers] = useState([]);
    const [tableUsers, setTableUsers] = useState([]);
    const cookies = new Cookies();
    const token = cookies.get("data");
    const handleClick = () => {
        navigate("/configuracion/0")
    };

    const onChange = (e) => {
        filtrarElementos(e.target.value);
    }

    const filtrarElementos = (terminoBusqueda) => {
        var search = tableUsers.filter(item => {
            if (item.nombre.toString().toLowerCase().includes(terminoBusqueda.toLocaleLowerCase())) {
                return item;
            }
        })
        setUsers(search);
    }

    const showData = () => {

        const URL = "https://localhost:7028/api/Usuario";
        const config = {
            headers: {
                Authorization: "Bearer " + token
            }
        }
        axios.get(URL, config)
            .then((response) => {
                setUsers(response.data);
                setTableUsers(response.data);
            }).catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        showData();
    }, []);

    const columns = [
         {
             name: "Nombre de Encargado",
             selector: (row) => row.nombre,
         },
         {
             name: "Correo",
             selector: (row) => row.correo,
         },
         {
             name: "Aciones",
             selector: (row) => (
                 <div className={styles.buttonsActionsContainer}>
                     <div>
                         <Link to={`/configuracion/${row.id}`}>
                             <Button icon={editIcon} variantIcon="backgroundBlue" />
                         </Link>
                     </div>
                     <div>
                         <Button icon={deleteIcon} variantIcon="backgroundBlue" />
                     </div>
                 </div>
              ),
         },
    ];

    const customStyles = {
        rows: {
            style: {
                background: "#DCDCDC",
                marginBottom: "8px",
                minHeight: "89px",
            },
        },
        headRow: {
            style: {
                background: "#0E1B8D",
                borderRadius: "6px 6px 6px 0px",
                marginBottom: "8px",
            },
        },
        headCells: {
            style: {
                color: "#FFF",
                fontSize: "24px",
                fontWeight: "700",
                paddingBottom: "23px",
                justifyContent: "center",
                paddingTop: "23px",
            },
        },
        cells: {
            style: {
                fontSize: "18px",
                fontWeight: "300",
                justifyContent: "center",
                lineHeight: "31.2px",
            },
        },
    };

    return (
        <div className={styles.tramiteContainer}>
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
                        <TitleHeader text="Catálogo de Usuarios" withoutIcon />
                    </div>
                    <div className={styles.formSearchContainer}>
                        <div className={styles.inputContainer}>
                            <Input placeholder="Buscar" type="text" variant="searchUser" onChange={onChange} />
                        </div>
                        <div className={styles.buttonContainer}>
                            <Button
                                text="+ Agregar nuevo usuario"
                                variant="addUserButton"
                                onClick={handleClick}
                            />
                        </div>
                    </div>
                    <div className={styles.tableContentContainer}>
                        <Table data={users} columns={columns} customStyles={customStyles} />
                    </div>
                </div>
            </div>
        </div>
    );
}
