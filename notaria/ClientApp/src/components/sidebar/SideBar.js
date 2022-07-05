import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux/es/exports";
import { open, close } from "../../actions/menuActions";
import styles from "./SideBar.module.scss";
import Button from "../button/Button";
import Logo from "../../images/logo.png";
import houseIcon from "../../icons/houseIcon.png";
import fileIconBlue from "../../icons/fileIconBlue.png";
import searchIcon from "../../icons/searchIcon.png";
import listIcon from "../../icons/listIcon.png";
import archiveFileIcon from "../../icons/archivesFileIcon.png";
import nutIcon from "../../icons/nutIcon.png";
import userIconSquare from "../../icons/userIconSquare.png";
import arrowBlue from "../../icons/arrowBlueIcon.png";

export default function SideBar({ handleStateBar }) {
    const state = useSelector((state) => state);
    const dispatch = useDispatch();
    const url = useLocation();

    return (
        <div
            className={
                state.stateMenu
                    ? styles.sideBarContainer
                    : `${styles.sideBarContainer} ${styles.sideBarClose}`
            }
        >
            <div className={styles.contentContainer}>
                <div
                    className={
                        state.stateMenu
                            ? styles.imageContainer
                            : `${styles.imageContainer} ${styles.imageContainerClose}`
                    }
                >
                    {state.stateMenu ? (
                        <div className={styles.iconContainer}>
                            <Button icon={arrowBlue} onClick={() => dispatch(close())} />
                        </div>
                    ) : (
                        <></>
                    )}
                    <div className={styles.logoContainer}>
                        <img
                            className={state.stateMenu ? styles.logo : styles.smallLogo}
                            src={Logo}
                            alt="Logo"
                        />
                    </div>
                    {!state.stateMenu ? (
                        <div className={styles.iconContainerClose}>
                            <Button
                                icon={arrowBlue}
                                onClick={() => dispatch(open())}
                                variantIcon="openSideBar"
                                variant="openSideBarButton"
                            />
                        </div>
                    ) : (
                        <></>
                    )}
                </div>
                <div className={styles.menuContainer}>
                    <div className={styles.optionsMenu}>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/inicio"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/inicio"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/inicio"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/inicio">
                                <Button icon={houseIcon} text="Inicio" openBar={state.stateMenu} />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/tramite"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/tramite"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/tramite"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/tramite">
                                <Button
                                    icon={fileIconBlue}
                                    text="Iniciar nuevo trámites"
                                    openBar={state.stateMenu}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/seguimiento-tramites"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/seguimiento-tramites"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/seguimiento-tramites"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/seguimiento-tramites">
                                <Button
                                    icon={searchIcon}
                                    text="Seguimiento Trámites"
                                    openBar={state.stateMenu}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/catalogo-responsable"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/catalogo-responsable"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/catalogo-responsable"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/catalogo-responsable">
                                <Button icon={listIcon} text="Catálogos" openBar={state.stateMenu} />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/catalogo-actos"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/catalogo-actos"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/catalogo-actos"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/catalogo-actos">
                                <Button
                                    icon={archiveFileIcon}
                                    text="Catálogo de actos"
                                    openBar={state.stateMenu}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/configuracion"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/configuracion"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/configuracion"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/configuracion">
                                <Button icon={nutIcon} text="Configuración" openBar={state.stateMenu} />
                            </Link>
                        </div>
                        <div
                            className={
                                state.stateMenu && url.pathname === "/"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : state.stateMenu && url.pathname !== "/"
                                        ? styles.optionContainer
                                        : !state.stateMenu && url.pathname === "/"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/">
                                <Button
                                    icon={userIconSquare}
                                    text="Usuarios"
                                    openBar={state.stateMenu}
                                />
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
