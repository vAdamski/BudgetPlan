import {Button, ButtonGroup, Table} from "react-bootstrap";

function TransactionTable({transactions, onEdit, onDelete}) {
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
            {transactions.map((trans) => (
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