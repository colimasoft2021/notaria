import React from "react";
import styles from "./Button.module.scss";

export default function Button({
    icon,
    onClick,
    text,
    variantIcon,
    variant,
    openBar,
    download,
    iconRight,
    type,
    id
}) {
    return (
        <button className={`${variant ? styles[variant] : ""}`} onClick={onClick} type={type}>
            {icon ? (
                <div
                    className={
                        iconRight
                            ? styles.iconRight
                            : icon && text && download
                                ? styles.iconDownload
                                : icon && text
                                    ? styles.iconButton
                                    : styles.withoutIcon
                    }
                >
                    {iconRight ? (
                        <>
                            <p>{text}</p>
                            <img
                                className={`${variantIcon ? styles[variantIcon] : ""}`}
                                src={icon}
                                alt={`Icono${text ? ` de ${text}` : ""}`}
                            />
                        </>
                    ) : (
                        <>
                            <img
                                className={`${variantIcon ? styles[variantIcon] : ""}`}
                                id={id}
                                src={icon}
                                alt={`Icono${text ? ` de ${text}` : ""}`}
                            />
                            {openBar ? <p>{text}</p> : download ? <p>{text}</p> : <></>}
                        </>
                    )}
                </div>
            ) : (
                <> {text} </>
            )}
        </button>
    );
}
