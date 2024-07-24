import PropTypes from "prop-types";
import useBudgetPlanBasesApi from "../../../services/api/budgetPlanBases.jsx";
import { useEffect, useState } from "react";
import TableHeader from "./TableHeader.jsx";
import MainCategoryRow from "./MainCategoryRow.jsx";
import { Table } from "react-bootstrap";

function BudgetPlanBaseTableView({ budgetPlanBaseId, dateFrom, dateTo }) {
    const { getBudgetPlanBasesForBudgetPlan } = useBudgetPlanBasesApi();
    const [budgetPlanBase, setBudgetPlanBase] = useState(null);
    const [handleUpdate, setHandleUpdate] = useState(false);

    const handleUpdateBudgetPlanBase = () => {
        setHandleUpdate(true);
    };

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanBaseId);
            setBudgetPlanBase(data);
            setHandleUpdate(false);
        };

        fetchBudgetPlanBases();
    }, [budgetPlanBaseId, handleUpdate]);

    return (
        <>
            <Table responsive bordered>
                <TableHeader dateFrom={dateFrom} dateTo={dateTo} />
                <tbody>
                {budgetPlanBase && budgetPlanBase.transactionCategoryDetailsViewDtos ? (
                    budgetPlanBase.transactionCategoryDetailsViewDtos.map((transactionCategoryDetailsViewDto, index) => (
                        <MainCategoryRow
                            key={index}
                            mainCategory={transactionCategoryDetailsViewDto}
                            handleUpdateBudgetPlanBase={handleUpdateBudgetPlanBase}
                        />
                    ))
                ) : (
                    <tr>
                        <td colSpan="2">Loading...</td>
                    </tr>
                )}
                </tbody>
            </Table>
        </>
    );
}

BudgetPlanBaseTableView.propTypes = {
    budgetPlanBaseId: PropTypes.string.isRequired,
};

export default BudgetPlanBaseTableView;