import {Button, ButtonGroup, Table} from "react-bootstrap";
import {useEffect, useState} from "react";

function TransactionTable({transactions, onEdit, onDelete}) {
    const [transactionsInside, setTransactionsInside] = useState([]);

    useEffect(() => {
        setTransactionsInside(transactions);
    }, [transactions]);


    return (
        <Table striped bordered hover>
            <thead>
            <tr>
                <th>Wartość</th>
                <th>Opis</th>
                <th>Data</th>
                <th>Akcje</th>
            </tr>
            </thead>
            <tbody>
            {transactionsInside.map((trans) => (
                <tr key={trans.id}>
                    <td>{trans.value}</td>
                    <td>{trans.description}</td>
                    <td>{trans.date}</td>
                    <td>
                        <ButtonGroup>
                            <Button variant="warning" onClick={() => onEdit(trans)}>Edytuj</Button>
                            <Button variant="danger" onClick={() => onDelete(trans.id)}>Usuń</Button>
                        </ButtonGroup>
                    </td>
                </tr>
            ))}
            </tbody>
        </Table>
    );
}

export default TransactionTable;