import { useState } from "react";
import { Link, useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";
import UnitChargeTable from "../UnitChargeTable";

function OwnedUnitCharges() {
  const { buildingId, unitId } = useParams();
  const charges = apiService.getRequest(`unit/owner/${unitI}/charge`);

  return (
    <>
      <UnitChargeTable rows={charges} />
    </>
  );
}

export default OwnedUnitCharges;
