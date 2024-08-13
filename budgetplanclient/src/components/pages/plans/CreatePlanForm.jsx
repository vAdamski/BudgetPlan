import {useState} from "react";
import DatePicker from "react-datepicker";

import "react-datepicker/dist/react-datepicker.css";
import {Button, Form, InputGroup} from "react-bootstrap";
import useBudgetPlanBasesApi from "../../../services/api/budgetPlanBases.jsx";
import {toDateString} from "../../../services/helpers/dateHelper.jsx";


function CreatePlanForm({budgetPlanId, handleUpdate}) {
    const {createBudgetPlanBase} = useBudgetPlanBasesApi();


    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date(new Date().setMonth(new Date().getMonth() + 1)));

    const handleCreate = async () => {
        const dateFrom = toDateString(startDate);
        const dateTo = toDateString(endDate);

        await createBudgetPlanBase(dateFrom, dateTo, budgetPlanId);

        handleUpdate();
    }

    return (
        <>
            <div className={'container-fluid'}>
                <div className={'d-flex justify-content-center align-content-center'}>
                    <Form onSubmit={handleCreate}>
                        <InputGroup className={'m-3'}>
                            <DatePicker
                                selected={startDate}
                                onChange={(date) => setStartDate(date)}
                                dateFormat="dd/MM/yyyy"
                                className={'form-control'}
                            />
                            <InputGroup.Text id="basic-addon1">do</InputGroup.Text>
                            <DatePicker
                                selected={endDate}
                                onChange={(date) => setEndDate(date)}
                                dateFormat="dd/MM/yyyy"
                                className={'form-control'}
                            />
                            <Button variant="outline-secondary" id="button-addon1" type={'submit'}>
                                Utwórz
                            </Button>
                        </InputGroup>
                    </Form>
                </div>
            </div>
        </>
    );
}

export default CreatePlanForm;