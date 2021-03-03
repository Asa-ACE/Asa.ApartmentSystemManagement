import { useState } from "react";
import { Link, useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";
import UnitChargeTable from "../UnitChargeTable";

function RentedUnitCharges() {
  const { buildingId, unitId } = useParams();
  const charges = apiService.getRequest(`unit/tenant/${unitId}/charge`);

  return (
    <>
      <UnitChargeTable rows={charges} />
    </>
  );
}
export default RentedUnitCharges;
