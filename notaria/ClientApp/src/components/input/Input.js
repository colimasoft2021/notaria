import React from "react";
import Button from "../button/Button";
import styles from "./Input.module.scss";

export default function Input({
    label,
    labelRight,
    icon,
    placeholder,
    type,
    onClick,
    variant,
    inputOverLabel,
    disabled,
    labelWithBackground,
}) {
    const isIcon = Boolean(icon);
    const hasLabel = Boolean(label);

    if (isIcon && hasLabel) {
        return (
            <div className={styles.inputWithIcon}>
                <div
                    className={
                        inputOverLabel
                            ? `${styles.label} ${styles.inputOverLabel}`
                            : styles.label
                    }
                >
                    <label>{label}</label>
                </div>
                <input
                    className={`${styles[variant]}`}
                    disabled={disabled}
                    type={type}
                    placeholder={placeholder}
                    onClick={onClick}
                />
                <div className={styles.iconInsideInput}>
                    <Button icon={icon} variantIcon="iconInside" onClick={onClick} />
                </div>
            </div>
        );
    }

    if (hasLabel) {
        return (
            <>
                {labelRight ? (
                    <div
                        className={
                            type === "checkbox"
                                ? labelWithBackground
                                    ? `${styles.checkboxContainer} ${styles.labelWithBackground}`
                                    : styles.checkboxContainer
                                : ""
                        }
                    >
                        <input
                            id={type === "checkbox" ? "inputCheckbox" : ""}
                            className={`${styles[variant]}`}
                            type={type}
                            placeholder={placeholder}
                            onClick={onClick}
                        />
                        <div
                            className={
                                inputOverLabel
                                    ? `${styles.label} ${styles.inputOverLabel}`
                                    : styles.label
                            }
                        >
                            <label htmlFor={type === "checkbox" ? "inputCheckbox" : ""}>
                                {label}
                            </label>
                        </div>
                    </div>
                ) : (
                    <div className={styles.inputContainer}>
                        <div
                            className={
                                inputOverLabel
                                    ? `${styles.label} ${styles.inputOverLabel}`
                                    : styles.label
                            }
                        >
                            <label>{label}</label>
                        </div>
                        <input
                            className={`${styles[variant]}`}
                            type={type}
                            placeholder={placeholder}
                            onClick={onClick}
                        />
                    </div>
                )}
            </>
        );
    }

    return (
        <div className={styles.inputContainer}>
            <input
                className={`${styles[variant]}`}
                type={type}
                placeholder={placeholder}
                onClick={onClick}
            />
        </div>
    );
}
