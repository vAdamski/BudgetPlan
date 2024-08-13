import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import {useEffect, useState} from "react";
import BudgetPlanBaseTableView from "./BudgetPlanBaseTableView.jsx";
import {Button, ButtonGroup, Col, Container, Row, Tab, Tabs} from "react-bootstrap";
import CreatePlanForm from "./CreatePlanForm.jsx";
import useBudgetPlanBasesApi from "../../../services/api/budgetPlanBases.jsx"; // Import the modal component

function Plans() {
    const {budgetPlanId} = useParams();
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlansApi();
    const {deleteBudgetPlanBase} = useBudgetPlanBasesApi();
    const [budgetPlanBases, setBudgetPlanBases] = useState([]);
    const [update, setUpdate] = useState(false);

    const handleUpdate = () => {
        setUpdate(!update);
    }

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanId);
            setBudgetPlanBases(data.budgetPlanBasesDtos || []);
        }

        fetchBudgetPlanBases().then();
    }, [budgetPlanId, update]);

    const handleDelete = async (budgetPlanBaseId) => {

        await deleteBudgetPlanBase(budgetPlanBaseId);

        handleUpdate();
    }

    return (
        <>
            <Container fluid>
                <Tabs id="uncontrolled-tab-example">
                    {budgetPlanBases.map((budgetPlanBase) => (
                        <Tab className={'border p-2'} key={budgetPlanBase.id} eventKey={budgetPlanBase.id}
                             title={`${budgetPlanBase.dateFrom} - ${budgetPlanBase.dateTo}`}>
                            <Container fluid>
                                <Row className={'mb-3'}>
                                    <Col className={'d-flex justify-content-end'}>
                                        <ButtonGroup>
                                            {/*<Button variant="primary" onClick={handleUpdate}>Odśwież</Button>*/}
                                            <Button variant="danger" onClick={() => handleDelete(budgetPlanBase.id)}>Usuń</Button>
                                        </ButtonGroup>
                                    </Col>
                                </Row>
                                <Row>
                                    <BudgetPlanBaseTableView budgetPlanBaseId={budgetPlanBase.id}
                                                             dateFrom={budgetPlanBase.dateFrom}
                                                             dateTo={budgetPlanBase.dateTo}/>
                                </Row>
                            </Container>
                        </Tab>
                    ))}
                    <Tab className={'border p-2'} title={'Utwórz'} eventKey={'x'}>
                        <CreatePlanForm budgetPlanId={budgetPlanId} handleUpdate={handleUpdate}/>
                    </Tab>
                </Tabs>
            </Container>
        </>
    );
}

export default Plans;