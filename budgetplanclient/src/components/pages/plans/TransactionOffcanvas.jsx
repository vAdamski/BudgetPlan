import { Offcanvas } from "react-bootstrap";
import { useEffect, useState } from "react";
import TransactionTable from './TransactionTable';
import TransactionForm from './TransactionForm';
import useTransactionDetailsApi from "../../../services/api/transactionDetails.jsx";

function TransactionOffcanvas({ show, handleClose, transactionCategoryId, selectedDay }) {
    const [transaction, setTransaction] = useState({ id: "", value: 0, description: "", date: selectedDay?.date || "" });

    const { createTransactionDetails, putTransactionDetails, deleteTransactionDetails } = useTransactionDetailsApi();

    useEffect(() => {
        setTransaction({ id: "", value: 0, description: "", date: selectedDay?.date || "" });
    }, [selectedDay]);

    const handleEdit = (trans) => {
        setTransaction(trans);
    };

    const handleSave = async (trans) => {
        const { id, value, description, date } = trans;

        if (id) {
            await putTransactionDetails(id, {
                transactionCategoryId: transactionCategoryId,
                value: value,
                description: description,
                transactionDate: date,
            });
        } else {
            await createTransactionDetails({
                transactionCategoryId: transactionCategoryId,
                value: value,
                description: description,
                transactionDate: date,
            });
        }
        setTransaction({ id: "", value: 0, description: "", date: selectedDay?.date || "" });
    };

    const handleDelete = async (id) => {
        await deleteTransactionDetails(id);
    };

    const handleCancel = () => {
        setTransaction({ id: "", value: 0, description: "", date: selectedDay?.date || "" });
    };

    return (
        <Offcanvas show={show} onHide={handleClose} placement="end">
            <Offcanvas.Header closeButton>
                <Offcanvas.Title>Transakcje dnia {selectedDay?.date}</Offcanvas.Title>
            </Offcanvas.Header>
            <Offcanvas.Body>
                {selectedDay && (
                    <>
                        <TransactionTable
                            transactions={selectedDay.transactionItemDtos}
                            onEdit={handleEdit}
                            onDelete={handleDelete}
                        />
                        <h5>{transaction.id ? "Edytuj transakcję" : "Dodaj nową transakcję"}</h5>
                        <TransactionForm
                            transaction={transaction}
                            date={selectedDay?.date || ""}
                            onSave={handleSave}
                            onCancel={handleCancel}  // Pass the handleCancel to the form
                        />
                    </>
                )}
            </Offcanvas.Body>
        </Offcanvas>
    );
}

export default TransactionOffcanvas;