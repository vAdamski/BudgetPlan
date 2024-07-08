import PropTypes from "prop-types";
import useBudgetPlanBasesApi from "../../../services/api/budgetPlanBases.jsx";
import {useEffect, useState} from "react";
import TableHeader from "./TableHeader.jsx";
import MainCategoryRow from "./MainCategoryRow.jsx";
import {Table} from "react-bootstrap";

function BudgetPlanBaseTableView({budgetPlanBaseId, dateFrom, dateTo}) {
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlanBasesApi();
    const [budgetPlanBase, setBudgetPlanBase] = useState(null);

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanBaseId);
            setBudgetPlanBase(data);
        }

        fetchBudgetPlanBases();
    }, [budgetPlanBaseId]);

    return (
        <>
            <Table responsive bordered>
                <TableHeader dateFrom={dateFrom} dateTo={dateTo}/>
                <tbody>
                {budgetPlanBase && budgetPlanBase.transactionCategoryDetailsViewDtos ? (
                    budgetPlanBase.transactionCategoryDetailsViewDtos.map(transactionCategoryDetailsViewDto => (
                        <MainCategoryRow
                            key={transactionCategoryDetailsViewDto.transactionCategoryName}
                            mainCategory={transactionCategoryDetailsViewDto}
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
}

export default BudgetPlanBaseTableView;